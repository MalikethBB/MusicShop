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
    public class ArtistRepo : Repository<Artist> , IArtistRepo
    {
        private readonly MusicDBContext _musicDBContext;
        public ArtistRepo(MusicDBContext musicDBContext) : base(musicDBContext)
        {
            _musicDBContext = musicDBContext;
        }

        public void SaveAll()
        {
            _musicDBContext.SaveChanges();
        }

        public IEnumerable<Artist> GetAll()
        {
            return _musicDBContext.Artists
                .Include(a => a.Songs)
                .ToList();
        }
    }
}
