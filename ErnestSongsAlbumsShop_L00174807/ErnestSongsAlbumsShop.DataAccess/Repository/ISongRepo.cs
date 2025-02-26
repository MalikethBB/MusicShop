using ErnestSongsAlbumsShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.DataAccess.Repository
{
    public interface ISongRepo : IRepository<Song>
    {
        public void Update (Song song);

        IEnumerable<Song> GetAll();

    }
}
