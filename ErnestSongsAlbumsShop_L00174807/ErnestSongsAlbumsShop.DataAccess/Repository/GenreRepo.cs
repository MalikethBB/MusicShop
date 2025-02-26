using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.DataAccess.Repository
{
    public class GenreRepo : Repository<Genre>, IGenreRepo
    {
        private readonly MusicDBContext _musicDBContext;
        public GenreRepo(MusicDBContext musicDBContext) : base(musicDBContext)
        {
            _musicDBContext = musicDBContext;
        }

        public void SaveAll()
        {
            _musicDBContext.SaveChanges();
        }

        public IEnumerable<Genre> GetAll()
        {
            return _musicDBContext.Genres
                .Include(a => a.Songs)
                .ThenInclude(a => a.Artist)
                .ToList();
        }
    }
}