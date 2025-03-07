using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Songs
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork unitOfWorkOps;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(IUnitOfWork UnitOfWorkOps, IWebHostEnvironment webHostEnvironment)
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

        public IActionResult OnPost(Song song)
        {
            if (ModelState.IsValid)
            {
                unitOfWorkOps.SongRepo.Add(song);
                unitOfWorkOps.Save();
            }
            return RedirectToPage("Index");
        }
    }
}   