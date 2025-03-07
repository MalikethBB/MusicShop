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
    public class AlbumRepo : Repository<Album>, IAlbumRepo
    {
        private readonly MusicDBContext _musicDBContext;
        public AlbumRepo(MusicDBContext musicDBContext) : base(musicDBContext)
        {
            _musicDBContext = musicDBContext;
        }

        public void Update(Album album)
        {
            var albumFromDB = _musicDBContext.Albums.
                FirstOrDefault(albumFromDB => albumFromDB.Id == album.Id);

            albumFromDB.Name = album.Name;
            albumFromDB.GenreId = album.GenreId;
            albumFromDB.ArtistId = album.ArtistId;

            if (album.ImageName != null)
                albumFromDB.ImageName = album.ImageName;

            _musicDBContext.SaveChanges();
        }

        public IEnumerable<Album> GetAll()
        {
            return _musicDBContext.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .Include(a => a.Songs)
                .ToList();
        }

        Album IAlbumRepo.GetAlbumGenre(int id)
        {
            var album = _musicDBContext.Albums.
                Include(a => a.Genre)
                .Include(a => a.Songs)
                .Include(a => a.Artist)
                .FirstOrDefault(a => a.Id == id);

            return album;
        }
    }
}
