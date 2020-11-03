using Microsoft.AspNetCore.Mvc;
using NorthwindWeb.Data;
using NorthwindWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductsController(NorthwindDbContext northwindDbContext)
        {
            _productRepository = new ProductRepository(northwindDbContext);
        }
        public ActionResult Index()
        {
            return this.Json(_productRepository.All());
        }
        public ActionResult Categories()
        {
            return this.Json(_productRepository.GetCategories());
        }

        public JsonResult Update()
        {
            var models = this.DeserializeObject<IEnumerable<Product>>("models");
            if (models != null)
            {
                _productRepository.Update(models);
            }
            return this.Json(models);
        }

        public ActionResult Destroy()
        {
            var products = this.DeserializeObject<IEnumerable<Product>>("models");

            if (products != null)
            {
                _productRepository.Delete(products);
            }
            return this.Json(products);
        }

        public ActionResult Create()
        {
            var products = this.DeserializeObject<IEnumerable<Product>>("models");
            if (products != null)
            {
                _productRepository.Insert(products);
            }
            return this.Json(products);
        }

        public JsonResult Read(int skip, int take)
        {
            IEnumerable<Product> result = _productRepository.All().OrderByDescending(p => p.ProductID);

            result = result.Skip(skip).Take(take);

            return this.Json(result);
        }

        public JsonResult Submit()
        {
            var model = this.DeserializeObject<ProductSubmitViewModel>("models");

            if (model != null && model.Created != null)
            {
                _productRepository.Insert(model.Created);
            }

            if (model != null && model.Updated != null)
            {
                _productRepository.Update(model.Updated);
            }

            if (model != null && model.Destroyed != null)
            {
                _productRepository.Delete(model.Destroyed);
            }

            return this.Json(model);
        }
    }
}
