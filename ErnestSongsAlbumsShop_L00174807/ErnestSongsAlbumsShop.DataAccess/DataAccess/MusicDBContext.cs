﻿using Microsoft.EntityFrameworkCore;
using ErnestSongsAlbumsShop.Models.Models;

namespace ErnestSongsAlbumsShop.DataAccess.DataAccess
{
    public class MusicDBContext : DbContext
    {

        public MusicDBContext(DbContextOptions<MusicDBContext> options) : base(options)
        {

        }
        public DbSet<Genre> Genres{ get; set; }
    }
}
