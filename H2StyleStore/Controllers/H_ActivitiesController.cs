using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace H2StyleStore.Controllers
{
	public class H_ActivitiesController : Controller
	{
		private H_ActivityService _hActivityService;
		private IH_ActivityRepository _repository;

		public H_ActivitiesController()
		{
			var _db = new AppDbContext();
			IH_ActivityRepository repo = new H_ActivityRepository(_db);
			_hActivityService = new H_ActivityService(repo);
			_repository = new H_ActivityRepository(_db);
		}

		// GET: H_Activities
		public ActionResult Index(string activityName)
		{
			ViewBag.ActivityName = activityName;

			IEnumerable<H_ActivityVM> data = _hActivityService.GetHActivity().Select(a => a.ToVM());
			// Search
			if (string.IsNullOrEmpty(activityName) == false)
			{
				data = data
					.Where(a => a.Activity_Name
					.Contains(activityName));
			}
			return View(data);
		}

		public ActionResult CreateActivity()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateActivity(H_ActivityVM model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				string create = _hActivityService.CreateNewActivity(model.ToDto());
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex);
				return View(model);
			}
		}

		[HttpGet]
		public ActionResult EditActivity(int id)
		{

			H_ActivityVM activity = _repository.GetHActivityById(id).ToVM();

			if (activity == null) return HttpNotFound();

			return View(activity);
		}

		[HttpPost]
		public ActionResult EditActivity(H_ActivityVM model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			H_ActivityDto request = model.ToDto();

			try
			{
				_hActivityService.UpdateActivity(request);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}

			if (ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}
			else { return View(model); }
		}

		// GET: H_Activities1/Delete/5
		//public ActionResult DeleteActivity(int? id)
		//{
		//	if (id == null)
		//	{
		//		return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//	}
		//	H_Activities h_Activities = db.H_Activities.Find(id);
		//	if (h_Activities == null)
		//	{
		//		return HttpNotFound();
		//	}
		//	return View(h_Activities);
		//}

		//// POST: H_Activities1/Delete/5
		//[HttpPost, ActionName("DeleteActivity")]
		//[ValidateAntiForgeryToken]
		//public ActionResult DeleteConfirmed(int id)
		//{
		//	H_Activities h_Activities = _db.H_Activities.Find(id);
		//	_db.H_Activities.Remove(h_Activities);
		//	_db.SaveChanges();
		//	return RedirectToAction("Index");
		//}
	}
}