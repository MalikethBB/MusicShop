using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErnestSongsAlbumsShop.DataAccess.Repository;

namespace ErnestSongsAlbumsShop.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IGenreRepo GenreRepo { get; }
        ISongRepo SongRepo { get; }
        IArtistRepo ArtistRepo { get; }
        IAlbumRepo AlbumRepo { get; }
        IOrderItemRepo OrderItemRepo { get; }
        IOrderRepo OrderRepo { get;}
        IShoppingCartRepo ShoppingCartRepo { get; }
        IApplicationUserRepo ApplicationUserRepo { get; }

        void Save();
    }
}