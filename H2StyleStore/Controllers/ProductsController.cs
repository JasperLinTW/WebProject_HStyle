using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Controllers
{
    public class ProductsController : Controller
    {
        private ProductService productService;

        public ProductsController()
        {
			var db = new AppDbContext();
            IProductRepository repo = new ProductRepository(db);
			this.productService = new ProductService(repo);
		}
        // GET: Products
        public ActionResult Index()
        {
            var data = productService.GetProducts()
                .Select(x => x.ToVM());
            
            return View(data);
        }

        public ActionResult CreateProduct()
        {
            //todo直接呼叫要改成三層式
            ViewBag.PCategories = new ProductRepository(new AppDbContext()).GetCategories();
            return View();
        }
    }
}