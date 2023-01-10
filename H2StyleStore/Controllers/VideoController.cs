using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures;
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
	public class VideoController : Controller
	{
		private VideoService _videoService;
		private IVideoRepository _videoRepository;

		public VideoController()
		{
			var db = new AppDbContext();
			IVideoRepository repo = new VideoRepository(db);
			this._videoService = new VideoService(repo);
		}

		// GET: Video
		public ActionResult Index()
		{
			var data = _videoService.GetVideos().Select(v => v.ToVM());
			return View(data);
		}

		public ActionResult CreateVideo()
		{
			ViewBag.VideoCategoryItems = new VideoRepository(new AppDbContext()).GetVideoCategories();
			return View();
		}

		[HttpPost]
		public ActionResult CreateVideo(CreateVideoVM model, HttpPostedFileBase file)
		{
			ViewBag.VidoeCategoryItems = new VideoRepository(new AppDbContext()).GetVideoCategories();


			if (file == null || string.IsNullOrEmpty(file.FileName) || file.ContentLength == 0)
			{
				model.Image = string.Empty;
			}
			
			var path = Server.MapPath("/Images/VideoImages");
			var helper = new UploadFileHelper();
			
			try
			{
				string result = helper.SaveAs(path, file);
				model.Image=result;
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, "上傳失敗: " + ex.Message);
			}

			try
			{
				(bool IsSuccess, string ErrorMessage) response = _videoService.CreateVideo(model.ToCreateDto());
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}

			if (ModelState.IsValid) return RedirectToAction("Index");
			return View(model);
		}
	}
}