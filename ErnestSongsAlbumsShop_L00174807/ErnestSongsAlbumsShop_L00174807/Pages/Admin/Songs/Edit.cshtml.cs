using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.DataAccess.Repository;
using ErnestSongsAlbumsShop.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Songs
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork unitOfWorkOps;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IUnitOfWork UnitOfWorkOps, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            unitOfWorkOps = UnitOfWorkOps;
        }

        public Song Song { get; set; }

        public IEnumerable<SelectListItem> ArtistList { get; set; }
        public IEnumerable<SelectListItem> AlbumList { get; set; }

        public void OnGet()
        {
            ArtistList = unitOfWorkOps.ArtistRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });

            AlbumList = unitOfWorkOps.AlbumRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                unitOfWorkOps.SongRepo.Update(Song);
                unitOfWorkOps.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
