using System.ComponentModel.DataAnnotations;

namespace ErnestSongsAlbumsShop.Models.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
