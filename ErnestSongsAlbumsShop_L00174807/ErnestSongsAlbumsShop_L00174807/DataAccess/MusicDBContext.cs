using Microsoft.EntityFrameworkCore;
using ErnestSongsAlbumsShop_L00174807.Models;

namespace ErnestSongsAlbumsShop_L00174807.DataAccess
{
    public class MusicDBContext : DbContext
    {

        public MusicDBContext(DbContextOptions<MusicDBContext> options) : base(options)
        {

        }
        public DbSet<Genre> Genres{ get; set; }
    }
}
