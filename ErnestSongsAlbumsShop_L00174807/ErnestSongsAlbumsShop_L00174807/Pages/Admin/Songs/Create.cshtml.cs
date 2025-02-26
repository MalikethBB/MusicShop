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

        public IEnumerable<SelectListItem> GenreList { get; set; }

        public void OnGet()
        {
            GenreList = unitOfWorkOps.GenreRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }

        public IActionResult OnPost(Song song)
        {
            string wwwRootFolder = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            string new_filename = Guid.NewGuid().ToString();

            var upload = Path.Combine(wwwRootFolder, @"Images\Songs");

            var extension = Path.GetExtension(files[0].FileName);
            using (var fileStream = new FileStream(Path.Combine(upload, new_filename + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            song.ImageName = @"\Images\Songs\" + new_filename + extension;
            if (ModelState.IsValid)
            {
                unitOfWorkOps.SongRepo.Add(song);
                unitOfWorkOps.Save();
            }
            return RedirectToPage("Index");
        }
    }
}   