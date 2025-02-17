using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.DataAccess.Repository;
using ErnestSongsAlbumsShop.Models.Models;
using ErnestSongsAlbumsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ErnestSongsAlbumsShop_L00174807.Pages.Admin.Songs
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Song> Songs;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Songs = _unitOfWork.SongRepo.GetAll();
        }
    }
}
