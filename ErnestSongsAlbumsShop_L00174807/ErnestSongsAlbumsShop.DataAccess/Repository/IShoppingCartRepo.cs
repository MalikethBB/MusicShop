using ErnestSongsAlbumsShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.DataAccess.Repository
{
    public interface IShoppingCartRepo : IRepository<ShoppingCart>
    {
        ShoppingCart IncrementItem(string userid, int id);

        int IncrementQty(ShoppingCart shoppingCart, int qty);

        public void Update(ShoppingCart shoppingCart)
        {

        }
    }
}
