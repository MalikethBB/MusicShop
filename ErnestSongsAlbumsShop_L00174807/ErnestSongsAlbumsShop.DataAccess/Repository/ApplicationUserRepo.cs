using ErnestSongsAlbumsShop.DataAccess.DataAccess;
using ErnestSongsAlbumsShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.DataAccess.Repository
{
    public class ApplicationUserRepo : Repository<ApplicationUser>, IApplicationUserRepo
    {
        private readonly MusicDBContext _dbContext;
        public ApplicationUserRepo(MusicDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicationUser Get(String s)
        {
            if (s == "")
                return null;
            else
                return _dbContext.ApplicationUsers.Where(u => u.Id == s).FirstOrDefault();
        }
    }
}
