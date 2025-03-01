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
    public class SongRepo : Repository<Song>, ISongRepo
    {
        private readonly MusicDBContext _musicDBContext;
        public SongRepo(MusicDBContext musicDBContext) : base(musicDBContext)
        {
            _musicDBContext = musicDBContext;
        }

        public void Update(Song song)
        {
            var songFromDB = _musicDBContext.Songs.
                FirstOrDefault(songFromDB => songFromDB.Id == song.Id);
            songFromDB.Name = song.Name;
            songFromDB.GenreId = song.GenreId;
            if (song.ImageName != null)
                songFromDB.ImageName = song.ImageName;
        } 

        public IEnumerable<Song> GetAll()
        {
            return _musicDBContext.Songs
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .ToList();
        }
    }
}
