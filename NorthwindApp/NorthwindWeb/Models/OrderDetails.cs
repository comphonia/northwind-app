using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindWeb.Models
{
    [Table("Order Details")]
    public class OrderDetails
    {
        [Key]
        public int ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
