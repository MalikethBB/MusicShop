using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicDBContext _dbContext;

        public IGenreRepo GenreRepo { get; private set; }

        public ISongRepo SongRepo { get; private set; }

        public IArtistRepo ArtistRepo { get; private set; }

        public IAlbumRepo AlbumRepo { get; private set; }

        public IOrderItemRepo OrderItemRepo { get; private set; }

        public IOrderRepo OrderRepo { get; private set; }

        public IApplicationUserRepo ApplicationUserRepo { get; private set; }

        public IShoppingCartRepo ShoppingCartRepo { get; private set; }

        public UnitOfWork(MusicDBContext appDBContext)
        {
            _dbContext = appDBContext;
            GenreRepo = new GenreRepo(_dbContext);
            SongRepo = new SongRepo(_dbContext);
            ArtistRepo = new ArtistRepo(_dbContext);
            AlbumRepo = new AlbumRepo(_dbContext);
            OrderRepo = new OrderRepo(_dbContext);
            OrderItemRepo = new OrderItemRepo(_dbContext);
            ApplicationUserRepo = new ApplicationUserRepo(_dbContext);
            ShoppingCartRepo = new ShoppingCartRepo(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}