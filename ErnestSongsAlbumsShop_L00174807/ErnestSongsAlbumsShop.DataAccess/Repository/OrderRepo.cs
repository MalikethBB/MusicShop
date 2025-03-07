using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.DataAccess.Repository
{
    public class OrderRepo : Repository<Order>, IOrderRepo
    {
        private readonly MusicDBContext _dbContext;
        public OrderRepo(MusicDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
