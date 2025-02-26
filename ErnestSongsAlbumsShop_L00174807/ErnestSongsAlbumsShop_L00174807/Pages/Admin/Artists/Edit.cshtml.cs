using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Artists
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Artist Artist { get; set; }
        public void OnGet(int id)
        {
            Artist = _unitOfWork.ArtistRepo.Get(id);
        }

        public IActionResult OnPost(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ArtistRepo.Update(artist);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
