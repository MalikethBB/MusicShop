using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Albums
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Album Album{ get; set; }
        public void OnGet(int id)
        {
            Album = _unitOfWork.AlbumRepo.Get(id);
        }

        public IActionResult OnPost(Album album)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AlbumRepo.Delete(Album);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
