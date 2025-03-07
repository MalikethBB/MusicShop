using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Customer.Home
{
    [Authorize(Roles = "Customer, Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }

        public void OnGet(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var album = _unitOfWork.AlbumRepo.GetAlbumGenre(id);

            ShoppingCart = new ShoppingCart
            {
                ApplicationUserID = claim.Value,
                Quantity = 1,
                Album = album,
                AlbumId = id
            };
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ShoppingCart shoppingCartFromDb = _unitOfWork.ShoppingCartRepo.IncrementItem(ShoppingCart.ApplicationUserID, ShoppingCart.AlbumId);
                if (shoppingCartFromDb == null)
                {
                    _unitOfWork.ShoppingCartRepo.Add(ShoppingCart);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.ShoppingCartRepo.IncrementQty(shoppingCartFromDb, ShoppingCart.Quantity);
                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
