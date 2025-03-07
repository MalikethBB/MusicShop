using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.DataAccess.Repository
{
    public class OrderItemRepo : Repository<OrderItem>, IOrderItemRepo
    {
        private readonly MusicDBContext _dbContext;
        public OrderItemRepo(MusicDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
