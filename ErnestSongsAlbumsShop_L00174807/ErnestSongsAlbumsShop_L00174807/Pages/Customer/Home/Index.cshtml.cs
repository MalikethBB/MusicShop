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

        public IEnumerable<Album> listOfAlbums{ get; set; }
        public IEnumerable<Genre> listOfGenres{ get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public void OnGet()
        {
            listOfAlbums = _unitOfWork.AlbumRepo.GetAll();
            listOfGenres = _unitOfWork.GenreRepo.GetAll();

            if (!string.IsNullOrEmpty(SearchString))
            {
                listOfAlbums= listOfAlbums.Where(p => p.Name.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
