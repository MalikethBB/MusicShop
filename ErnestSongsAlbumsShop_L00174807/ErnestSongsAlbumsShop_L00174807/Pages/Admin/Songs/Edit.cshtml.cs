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

        public IEnumerable<SelectListItem> GenreList { get; set; }

        public void OnGet(int id)
        {
            Song = unitOfWorkOps.SongRepo.Get(id);
            GenreList = unitOfWorkOps.GenreRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }

        public IActionResult OnPost()
        {
            string wwwRootFolder = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var songFromDB = unitOfWorkOps.SongRepo.Get(Song.Id);

            if (files.Count > 0)
            {
                string new_filename = Guid.NewGuid().ToString();

                var upload = Path.Combine(wwwRootFolder, @"Images\Products");

                var extension = Path.GetExtension(files[0].FileName);
                if (songFromDB != null)
                {
                    var oldFile = Path.Combine(wwwRootFolder, songFromDB.ImageName.TrimStart('\\'));
                    if (System.IO.File.Exists(oldFile))
                        System.IO.File.Delete(oldFile);
                }
                using (var fileStream = new FileStream(Path.Combine(upload, new_filename + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                Song.ImageName = @"\Images\Songs\" + new_filename + extension;
            }
            if (ModelState.IsValid)
            {
                unitOfWorkOps.SongRepo.Update(Song);
                unitOfWorkOps.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
