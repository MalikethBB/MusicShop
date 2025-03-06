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

        public void AddSongToAlbum(int albumId, Song song)
        {
            var album = _musicDBContext.Albums
                .Include(a => a.Songs)
                .FirstOrDefault(a => a.Id == albumId);

            if (album != null)
            {
                song.AlbumId = albumId;
                album.Songs.Add(song);
                _musicDBContext.SaveChanges();
            }
        }

        public void UpdateSong(Song song)
        {
            var songFromDB = _musicDBContext.Songs
                .FirstOrDefault(s => s.Id == song.Id);

            if (songFromDB != null)
            {
                songFromDB.Name= song.Name;
                _musicDBContext.SaveChanges();
            }
        }

        public void RemoveSongFromAlbum(int songId)
        {
            var songFromDB = _musicDBContext.Songs
                .FirstOrDefault(s => s.Id == songId);

            if (songFromDB != null)
            {
                _musicDBContext.Songs.Remove(songFromDB);
                _musicDBContext.SaveChanges();
            }
        }
    }
}
