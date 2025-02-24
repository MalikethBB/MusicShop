using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErnestSongsAlbumsShop.DataAccess.Repository;

namespace ErnestSongsAlbumsShop.Services
{
    public  interface IUnitOfWork : IDisposable
    {
        IGenreRepo GenreRepo { get; }

        ISongRepo SongRepo { get; }

        void Save();
    }
}