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

        public DbSet<Album> Albums { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Genre)
                .WithMany(g => g.Albums)
                .HasForeignKey(a => a.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}