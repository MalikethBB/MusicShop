using System.ComponentModel.DataAnnotations;

namespace ErnestSongsAlbumsShop_L00174807.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
