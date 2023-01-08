using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.Win32;
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

        public static string select_user_name;
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
			ViewBag.PCategoryItems = new ProductRepository(new AppDbContext()).GetCategories();
            return View();
        }
		[HttpPost]
		public ActionResult CreateProduct(ProductVM product)
		{
			ViewBag.PCategoryItems = new ProductRepository(new AppDbContext()).GetCategories();
			try
			{
				var productDto = product.ToDto();


				(bool IsSuccess, string ErrorMessage) result = productService.Create(productDto);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}


			if (ModelState.IsValid)
			{

				return RedirectToAction("Index");
			}

			return View(product);

			
		}
		
	}
}