using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.DataAccess.DataAccess;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Genres
{
    public class DeleteModel : PageModel
    {
        private readonly MusicDBContext _dbContext;

        public DeleteModel(MusicDBContext dbContext)
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
                _dbContext.Genres.Remove(genre);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}