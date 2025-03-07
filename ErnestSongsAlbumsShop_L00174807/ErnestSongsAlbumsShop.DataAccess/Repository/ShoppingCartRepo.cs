using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.DataAccess.Repository
{
    public class ShoppingCartRepo : Repository<ShoppingCart>, IShoppingCartRepo
    {
        private readonly MusicDBContext _dbContext;
        public ShoppingCartRepo(MusicDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(ShoppingCart shoppingCart)
        {
            _dbContext.ShoppingCarts.Add(shoppingCart);
        }

        public ShoppingCart IncrementItem(string userid, int id)
        {
            var ShoppingCartItem = _dbContext.ShoppingCarts.Where(a => a.AlbumId== id && a.ApplicationUserID == userid).FirstOrDefault();

            return ShoppingCartItem;
        }

        public int IncrementQty(ShoppingCart shoppingCart, int qty)
        {
            shoppingCart.Quantity += qty;
            _dbContext.SaveChanges();
            return shoppingCart.Quantity;
        }
    }
}
