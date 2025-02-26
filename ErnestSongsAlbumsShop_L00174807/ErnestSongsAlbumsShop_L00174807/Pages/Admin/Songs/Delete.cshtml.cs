using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.DataAccess.Repository;
using ErnestSongsAlbumsShop.Services;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Songs
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Song Song { get; set; }
        public void OnGet(int id)
        {
            Song = _unitOfWork.SongRepo.Get(id);
        }

        public IActionResult OnPost(Song song)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.SongRepo.Delete(song);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}