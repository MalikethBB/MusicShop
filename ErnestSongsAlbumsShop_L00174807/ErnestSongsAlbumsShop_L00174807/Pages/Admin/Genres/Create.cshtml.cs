using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.Models.Models;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Genres 
{
    public class CreateModel : PageModel
    {
        private readonly MusicDBContext _dbContext;

        public CreateModel(MusicDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Genre Genre{ get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Genres.AddAsync(genre);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
