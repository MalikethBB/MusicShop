using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.DataAccess.Repository;
using ErnestSongsAlbumsShop.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Genres
{
    public class IndexModel : PageModel
    {
        private readonly IGenreRepo _genreRepo;
        public IEnumerable<Genre> Genres;

        public IndexModel(IGenreRepo genreRepo)
        {
            _genreRepo = genreRepo;
        }
        public void OnGet()
        {
            Genres = _genreRepo.GetAll();
        }
    }
}
