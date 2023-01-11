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
		private IH_Source_DetailRepository _repository;

		public H_Source_DetailsController()
		{
			var db = new AppDbContext();
			_repository = new H_Source_DetailRepository(db);
			this._detailService = new H_Source_DetailService(_repository);
		}

		// GET: H_Source_Details
		public ActionResult HDetail()
			//(int? activityId, string activityName, int pageNumber = 1)
		{
			//pageNumber = pageNumber > 0 ? pageNumber : 1;                                                                                                                                                                                                                                                                                                                                                                                                                            
			// 將篩選條件放在ViewBag,稍後在 view page取回
			//ViewBag.Activities = _detailService.GetActivities(activityId);
			//ViewBag.ActivityName = activityName;
			//ViewBag.ActivityId = activityId;

			var data = _detailService.GetSource().Select(x => x.ToVM());
			return View(data);
		}

		

		public ActionResult CheckIn()
		{
			var data = _detailService.GetCheckIn().Select(x => x.ToVM());
			return View(data);
		}	

		public ActionResult DeleteDetail(int? id)
		{
			if (id == null) return View("Index");

			H_Source_DetailVM hDetail = _repository.FindDetail(id).ToVM();
			
			if (hDetail == null) return HttpNotFound();

			return View(hDetail);
		}

		// POST: H_Activities1/Delete/5
		[HttpPost, ActionName("DeleteActivity")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_repository.DeleteDetail(id);
			return RedirectToAction("Index");
		}
	}
}