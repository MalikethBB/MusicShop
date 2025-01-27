using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.DataAccess.DataAccess;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Genres
{
    public class EditModel : PageModel
    {
        private readonly MusicDBContext _dbContext;

        public EditModel(MusicDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Genre Genre { get; set; }
        public void OnGet(int id)
        {
            Genre = _dbContext.Genres.Find(id);
        }

        public async Task<IActionResult> OnPost(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Genres.Update(genre);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
