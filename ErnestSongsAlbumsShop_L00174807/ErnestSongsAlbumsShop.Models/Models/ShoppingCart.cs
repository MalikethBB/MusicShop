using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErnestSongsAlbumsShop.Models.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        [ValidateNever]
        public Album Album { get; set; }

        public int Quantity { get; set; }

        public float CartTotal { get; set; }

        //Foreign Key
        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
