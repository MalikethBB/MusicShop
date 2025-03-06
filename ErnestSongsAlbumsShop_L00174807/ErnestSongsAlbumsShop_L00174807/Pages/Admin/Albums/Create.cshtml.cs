using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Albums
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

        public Album Album { get; set; }
        public List<Song> Songs { get; set; }

        public IEnumerable<SelectListItem> GenreList { get; set; }
        public IEnumerable<SelectListItem> ArtistList { get; set; }

        public void OnGet()
        {
            GenreList = unitOfWorkOps.GenreRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });

            ArtistList = unitOfWorkOps.ArtistRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }

        public IActionResult OnPost(Album album)
        {
            string wwwRootFolder = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            string new_filename = Guid.NewGuid().ToString();

            var upload = Path.Combine(wwwRootFolder, @"Images\Albums");

            var extension = Path.GetExtension(files[0].FileName);
            using (var fileStream = new FileStream(Path.Combine(upload, new_filename + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            album.ImageName = @"\Images\Albums\" + new_filename + extension;
            if (ModelState.IsValid)
            {
                unitOfWorkOps.AlbumRepo.Add(album);
                unitOfWorkOps.Save();

                foreach (var song in Songs)
                {
                    unitOfWorkOps.AlbumRepo.AddSongToAlbum(Album.Id, song);
                }
            }
            return RedirectToPage("Index");
        }
    }
}
