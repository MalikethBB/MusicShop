using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.Models.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public ICollection<Song>? Songs { get; set; }
        public List<Album>? Albums { get; set; } = new List<Album>();
    }
}
