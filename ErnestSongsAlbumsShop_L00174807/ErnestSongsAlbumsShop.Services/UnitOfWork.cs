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

        public UnitOfWork(MusicDBContext appDBContext)
        {
            _dbContext = appDBContext;
            GenreRepo = new GenreRepo(_dbContext);
            SongRepo = new SongRepo(_dbContext);
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