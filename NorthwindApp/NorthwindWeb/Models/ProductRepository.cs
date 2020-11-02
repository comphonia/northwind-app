using NorthwindWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindWeb.Models
{
    public class ProductRepository
    {
        private NorthwindDbContext _northwindDbContext;

        public ProductRepository(NorthwindDbContext northwindDbContext)
        {
            _northwindDbContext = northwindDbContext;
        }

        public IList<Product> All()
        {
            var result = _northwindDbContext.Products as IList<Product>;

            if (result == null)
            {
                result =
                     _northwindDbContext.Products.Select(p => new Product
                     {
                         ProductID = p.ProductID,
                         ProductName = p.ProductName,
                         Category = "Test",
                         UnitPrice = p.UnitPrice,
                         UnitsInStock = p.UnitsInStock,
                         Discontinued = p.Discontinued
                     }).ToList();
            }

            return result;
        }

        public Product One(Func<Product, bool> predicate)
        {
            return All().FirstOrDefault(predicate);
        }

        public void Insert(Product product)
        {
            var first = All().OrderByDescending(p => p.ProductID).FirstOrDefault();
            if (first != null)
            {
                product.ProductID = first.ProductID + 1;
            }
            else
            {
                product.ProductID = 0;
            }

            All().Insert(0, product);
        }

        public void Insert(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Insert(product);
            }
        }

        public void Update(Product product)
        {
            var target = One(p => p.ProductID == product.ProductID);
            if (target != null)
            {
                target.ProductName = product.ProductName;
                target.UnitPrice = product.UnitPrice;
                target.UnitsInStock = product.UnitsInStock;
                target.Discontinued = product.Discontinued;
            }
        }

        public void Update(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Update(product);
            }
        }

        public void Delete(Product product)
        {
            var target = One(p => p.ProductID == product.ProductID);
            if (target != null)
            {
                All().Remove(target);
            }
        }

        public void Delete(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Delete(product);
            }
        }
    }
}
