using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ErnestSongsAlbumsShop_L00174807.DataAccess;
using ErnestSongsAlbumsShop_L00174807.Models;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Genres
{
    public class DeleteModel : PageModel
    {
        private readonly MusicDBContext _dbContext;

        public DeleteModel(MusicDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Models.Genre Genre { get; set; }
        public void OnGet(int id)
        {
            Genre = _dbContext.Genres.Find(id);
        }

        public async Task<IActionResult> OnPost(Models.Genre genre)
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