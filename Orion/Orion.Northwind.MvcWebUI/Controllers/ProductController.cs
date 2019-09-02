using Orion.Northwind.Business.Abstract;
using Orion.Northwind.Entities.Concrete;
using Orion.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orion.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
        };
            return View(model);
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "Computer 1",
                QuantityPerUnit = "1",
                UnitPrice = 21
            }, new Product
            {
                CategoryId = 1,
                ProductName = "Computer 2",
                QuantityPerUnit = "1",
                UnitPrice = 3,
                ProductId = 2
            }
            );
            return "Done";
        }
    }
}