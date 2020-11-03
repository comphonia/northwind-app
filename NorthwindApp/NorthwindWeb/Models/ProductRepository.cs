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

        public Array GetCategories()
        {
            var categories = _northwindDbContext.Categories.Select(c => c).ToArray();

            return categories;
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
                         CategoryID = p.CategoryID,
                         Category = new Category
                         {
                             CategoryID = p.CategoryID,
                             CategoryName = _northwindDbContext.Categories
                            .Where(c => c.CategoryID == p.CategoryID)
                            .Select(n => n.CategoryName).FirstOrDefault()
                         },
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
            var tempProduct = new Product
            {
                ProductName = product.ProductName,
                CategoryID = product.Category.CategoryID,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                Discontinued = product.Discontinued
            };
            _northwindDbContext.Products.Add(tempProduct);
            _northwindDbContext.SaveChanges();
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
                target = new Product
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    CategoryID = product.Category.CategoryID,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    Discontinued = product.Discontinued
                };
                _northwindDbContext.Products.Update(target);
                _northwindDbContext.SaveChanges();
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
            var targetOrderDetails = _northwindDbContext.OrderDetails.Where(o => o.ProductID == target.ProductID).ToArray();

            if (target != null)
            {
                // delete from the order table first to break the FK constraint

                _northwindDbContext.OrderDetails.RemoveRange(targetOrderDetails);
                _northwindDbContext.SaveChangesAsync();

                _northwindDbContext.Products.Remove(target);
                _northwindDbContext.SaveChangesAsync();
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
