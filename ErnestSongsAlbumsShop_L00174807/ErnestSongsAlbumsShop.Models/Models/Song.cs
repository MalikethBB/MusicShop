using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.Models.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? ImageName { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
