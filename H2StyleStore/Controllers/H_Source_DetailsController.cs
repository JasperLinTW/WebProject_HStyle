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
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Controllers
{
	public class H_Source_DetailsController : Controller
	{
		private H_Source_DetailService _detailService;

		public H_Source_DetailsController()
		{
			var db = new AppDbContext();
			IH_Source_DetailRepository repo = new H_Source_DetailRepository(db);
			this._detailService = new H_Source_DetailService(repo);

		}

		// GET: H_Source_Details
		public ActionResult HDetail()
		{
			var data = _detailService.GetSource().Select(x => x.TovM());
			return View(data);
		}

		public ActionResult CheckIn()
		{
			var data = _detailService.GetCheckIn().Select(x => x.ToVM());
			return View(data);
		}	

		
	}
}