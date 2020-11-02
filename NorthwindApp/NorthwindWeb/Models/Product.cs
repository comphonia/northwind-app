namespace NorthwindWeb.Models
{
    public class Product
    {
        public long Id { get; set; }

        public string _key;

        public string Key
        {
            get
            {
                if (_key == null)
                {
                    _key = ProductID.ToString();
                }
                return _key;
            }
            set { _key = value; }
        }
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}
