using ErnestSongsAlbumsShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.DataAccess.Repository
{
    public interface IOrderItemRepo : IRepository<OrderItem>
    {
        public void Update(Order order)
        {

        }
    }
}
