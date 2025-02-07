using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.DataAccess.Repository;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Genres
{
    public class EditModel : PageModel
    {
        private readonly IGenreRepo _genreRepo;

        public EditModel(IGenreRepo genreRepo)
        {
            _genreRepo = genreRepo;
        }

        public Genre Genre { get; set; }
        public void OnGet(int id)
        {
            Genre = _genreRepo.Get(id);
        }

        public IActionResult OnPost(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreRepo.Update(genre);
                _genreRepo.SaveAll();
            }
            return RedirectToPage("Index");
        }
    }
}
