using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.Models.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? ImageName { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
