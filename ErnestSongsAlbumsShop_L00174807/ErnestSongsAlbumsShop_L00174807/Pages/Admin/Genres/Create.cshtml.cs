using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.DataAccess.Repository;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Genres 
{
    public class CreateModel : PageModel
    {
        private readonly IGenreRepo _genreRepo;

        public CreateModel(IGenreRepo  genreRepo)
        {
            _genreRepo = genreRepo;
        }

        public Genre Genre{ get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreRepo.Add(genre);
                _genreRepo.SaveAll();
            }
            return RedirectToPage("Index");
        }
    }
}
