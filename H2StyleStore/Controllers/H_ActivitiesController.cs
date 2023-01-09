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
			var db = new AppDbContext();
			IH_ActivityRepository repo = new H_ActivityRepository(db);
			_hActivityService = new H_ActivityService(repo);
		}

		// GET: H_Activities
		public ActionResult Index(string activityName)
		{
			ViewBag.ActivityName = activityName;

			var data = _hActivityService.GetHActivity().Select(a => a.ToVM());

			// Search
			if (string.IsNullOrEmpty(activityName) == false) data = data
					.Where(a => a.Activity_Name
					.Contains(activityName));

			return View(data);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(H_ActivityVM model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var service = new H_ActivityService(_repository);

			try
			{
				string create = _hActivityService.CreateNewActivity(model.ToDto());
				return View("Index");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex);
				return View(model);
			}
		}

		[HttpGet]
		public ActionResult GetHActivityItem(int id)
		{
			var activity = _repository.GetHActivityById(id).ToVM();

			if (activity == null) return HttpNotFound();

			return View(activity);
		}

		[HttpPost]
		public ActionResult GetHActivityItem(H_ActivityVM model)
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
	}
}