using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Genres
{
    public class IndexModel : PageModel
    {
        private readonly MusicDBContext _dbContext;
        public IEnumerable<Genre> Genres;

        public IndexModel(MusicDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            Genres = _dbContext.Genres;
        }
    }
}
