using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.Models.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateOfOrder { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public float TotalAMtDue { get; set; }

        public List<Order> OrderDetails { get; set; }
    }
}
