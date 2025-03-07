using ErnestSongsAlbumsShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.DataAccess.Repository
{
    public interface IApplicationUserRepo : IRepository<ApplicationUser>
    {
        ApplicationUser Get(String s);
        public void Update(ApplicationUser applicationUser)
        {

        }
    }
}
