using ErnestSongsAlbumsShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.DataAccess.Repository
{
    public interface IAlbumRepo : IRepository<Album>
    {
        public void Update(Album album);

        IEnumerable<Album> GetAll();  
        
        void AddSongToAlbum (int albumId, Song song);
        void UpdateSong(Song song);
        void RemoveSongFromAlbum(int songId);
    }
}