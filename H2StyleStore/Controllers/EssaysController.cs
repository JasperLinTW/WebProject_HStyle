using H2StyleStore.Models;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Controllers
{
    public class EssaysController : Controller
    {
		private EssayService essayService;

		public EssaysController()
		{
			var db = new AppDbContext();
			IEssayRepository repo = new EssayRepository(db);
			this.essayService = new EssayService(repo);
		}
		// GET: Products
		public ActionResult Index()
		{
			var data = essayService.GetEssays()
				.Select(x => x.ToVM());

			return View(data);
		}
		public ActionResult Uploadblog()
        {
            return View();
        }
  //      [HttpPost]
  //      public ActionResult Uploadblog(Essay bg)
		//{
         
		//}
	}
}