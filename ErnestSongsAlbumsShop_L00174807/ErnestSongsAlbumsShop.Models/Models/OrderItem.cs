using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErnestSongsAlbumsShop.Models.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public Album Album{ get; set; }

        public int QtyOrdered { get; set; }

        //ForeignKey to Order Table
        public int OrderID { get; set; }

        //Reference Navigation Property
        public Order Order { get; set; }
    }
}
