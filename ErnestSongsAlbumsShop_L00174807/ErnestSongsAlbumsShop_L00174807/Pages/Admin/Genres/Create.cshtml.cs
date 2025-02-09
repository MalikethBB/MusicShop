using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.Services;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Genres 
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Genre Genre{ get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GenreRepo.Add(genre);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
