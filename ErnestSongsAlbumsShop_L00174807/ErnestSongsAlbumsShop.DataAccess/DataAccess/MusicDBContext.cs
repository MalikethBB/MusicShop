using Microsoft.EntityFrameworkCore;
using ErnestSongsAlbumsShop.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ErnestSongsAlbumsShop.DataAccess.DataAccess
{
    public class MusicDBContext : IdentityDbContext
    {

        public MusicDBContext(DbContextOptions<MusicDBContext> options) : base(options)
        {

        }
        public DbSet<Genre> Genres{ get; set; }

        public DbSet<Song> Songs{ get; set; }

        public DbSet<Artist> Artists{ get; set; }
    }
}
