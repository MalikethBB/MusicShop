using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Artists
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Artist Artist { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ArtistRepo.Add(artist);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}