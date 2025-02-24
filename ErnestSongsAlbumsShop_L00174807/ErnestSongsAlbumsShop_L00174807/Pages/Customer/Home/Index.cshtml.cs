using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Song> listOfSongs{ get; set; }
        public IEnumerable<Genre> listOfGenres{ get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public void OnGet()
        {
            listOfSongs = _unitOfWork.SongRepo.GetAll();
            listOfGenres = _unitOfWork.GenreRepo.GetAll();

            if (!string.IsNullOrEmpty(SearchString))
            {
                listOfSongs= listOfSongs.Where(p => p.Name.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
