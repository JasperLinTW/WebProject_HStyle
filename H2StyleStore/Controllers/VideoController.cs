using H2StyleStore.Models.DTOs;
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
			return View();
		}

		[HttpPost]
		public ActionResult CreateVideo(CreateVideoVM model)
		{
			if (!ModelState.IsValid) return View(model);
			(bool IsSuccess, string ErrorMessage) response = _videoService.CreateVideo(model.VMToDto());

			if (response.IsSuccess)
			{
				return View("新增成功");
			}
			else
			{
				ModelState.AddModelError(string.Empty, response.ErrorMessage);
				return View(model);
			}
		}
	}
}