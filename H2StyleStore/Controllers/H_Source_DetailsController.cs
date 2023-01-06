using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Controllers
{
	public class H_Source_DetailsController : Controller
	{
		private H_Source_DetailService detailService;
		public H_Source_DetailsController()
		{
			var db = new AppDbContext();
			IH_Source_DetailRepository repo = new H_Source_DetailRepository(db);
			this.detailService = new H_Source_DetailService(repo);

		}

		// GET: H_Source_Details
		public ActionResult Index()
		{
			var data = detailService.GetSource().Select(x => x.TovM());
			return View(data);
		}
	}
}