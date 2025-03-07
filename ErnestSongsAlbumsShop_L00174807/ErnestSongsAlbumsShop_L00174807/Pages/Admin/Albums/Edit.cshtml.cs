using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Albums
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

        public Album Album { get; set; }

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

        public IActionResult OnPost()
        {
            string wwwRootFolder = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var albumFromDB = unitOfWorkOps.AlbumRepo.Get(Album.Id);

            if (files.Count > 0)
            {
                string new_filename = Guid.NewGuid().ToString();

                var upload = Path.Combine(wwwRootFolder, @"Images\Albums");

                var extension = Path.GetExtension(files[0].FileName);
                if (albumFromDB != null)
                {
                    var oldFile = Path.Combine(wwwRootFolder, albumFromDB.ImageName.TrimStart('\\'));
                    if (System.IO.File.Exists(oldFile))
                        System.IO.File.Delete(oldFile);
                }
                using (var fileStream = new FileStream(Path.Combine(upload, new_filename + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                Album.ImageName = @"\Images\Albums\" + new_filename + extension;
            }
            if (ModelState.IsValid)
            {
                unitOfWorkOps.AlbumRepo.Update(Album);
                unitOfWorkOps.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
