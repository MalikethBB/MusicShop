using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.Models.Models;
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
    }
}