using System.Collections.Generic;

namespace NorthwindWeb.Models
{
    public class ProductSubmitViewModel
    {
        public IList<Product> Created { get; set; }

        public IList<Product> Destroyed { get; set; }

        public IList<Product> Updated { get; set; }
    }
}
