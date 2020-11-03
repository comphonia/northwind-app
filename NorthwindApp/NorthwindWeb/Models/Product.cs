namespace NorthwindWeb.Models
{

    public class Product
    {
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}
