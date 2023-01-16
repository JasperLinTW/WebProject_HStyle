using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;
using System.Xml.Linq;

namespace H2StyleStore.Controllers
{
	public class VideoController : Controller
	{
		private VideoService _videoService;
		private readonly IVideoRepository _videoRepository;
		private AppDbContext _db = new AppDbContext();
		public VideoController()
		{
			var db = new AppDbContext();
			_videoRepository = new VideoRepository(db);
			IVideoRepository repo = new VideoRepository(db);
			this._videoService = new VideoService(repo);
		}

		// GET: Video
		//public ActionResult Index()
		//{
		//	var data = _videoService.GetVideos().Select(v => v.ToVM());
		//	return View(data);
		//}

		public ActionResult Index(int? categoryId, string videoTitle, string tagName)
		{
			// 將篩選條件放在ViewBag,稍後在 view page取回
			ViewBag.Categories = _videoRepository.GetVideoCategories(categoryId);
			ViewBag.VideoTitle = videoTitle;
			ViewBag.TagName = tagName;

			var data = _videoService.GetVideos().Select(x => x.ToVM());

			// 若有篩選categoryid
			if (categoryId.HasValue) data = data.Where(p => p.CategoryId == categoryId.Value);

			// 若有篩選 productName
			if (string.IsNullOrEmpty(videoTitle) == false) data = data.Where(p => p.Title.Contains(videoTitle));
			// data = data.Where(p => Left(p.Name)=="AB");

			//Tag篩選
			if (string.IsNullOrEmpty(tagName) == false) data = data.Where(p => p.Tags.Contains(tagName));

			return View(data);
		}

		public ActionResult CreateVideo()
		{
			ViewBag.VideoCategoryItems = _videoRepository.GetVideoCategories();
			return View();
		}

		[HttpPost]
		public ActionResult CreateVideo(CreateVideoVM model, HttpPostedFileBase videoFile, HttpPostedFileBase imageFile)
		{
			ViewBag.VidoeCategoryItems = _videoRepository.GetVideoCategories();


			if (videoFile == null || string.IsNullOrEmpty(videoFile.FileName) || videoFile.ContentLength == 0)
			{
				model.Image = string.Empty;
			}

			if (imageFile == null || string.IsNullOrEmpty(imageFile.FileName) || imageFile.ContentLength == 0)
			{
				model.FilePath = string.Empty;
			}

			var imagePath = Server.MapPath("/Images/VideoImages");
			var videoPath = Server.MapPath("/videos");
			var helper = new UploadFileHelper();

			try
			{
				string imageSave = helper.SaveAs(imagePath, imageFile);
				model.Image = imageSave;
				string videoSave = helper.SaveAs(videoPath, videoFile);
				model.FilePath = videoSave;
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, "影片上傳失敗: " + ex.Message);
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

		public ActionResult EditVideo(int id)
		{
			EditVideoVM model = _videoRepository.GetVideoById(id).ToEditVM();
			var videoCategory = _videoRepository.GetVideoCategories(id).ToList();
			ViewBag.VideoCategoryItems = videoCategory;

			if (model == null) return HttpNotFound();
			return View(model);
		}

		[HttpPost]
		public ActionResult EditVideo(EditVideoVM model, HttpPostedFileBase videoFile, HttpPostedFileBase imageFile)
		{
			//var data=_videoRepository.GetVideoById(model.Id);
			var videoCategory = _videoRepository.GetVideoCategories(model.Id);
			ViewBag.VideoCategoryItems = videoCategory;


			//---------test---------

			var imagePath = Server.MapPath("/Images/VideoImages");
			var videoPath = Server.MapPath("/videos");
			var helper = new UploadFileHelper();
			if (videoFile == null || string.IsNullOrEmpty(videoFile.FileName) || videoFile.ContentLength == 0)
			{
				model.FilePath = model.FilePath;
			}
			else
			{
				try
				{
					string videoSave = helper.SaveAs(videoPath, videoFile);
					model.FilePath = videoSave;
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, "影片上傳失敗: " + ex.Message);
				}
			}

			if (imageFile == null || string.IsNullOrEmpty(imageFile.FileName) || imageFile.ContentLength == 0)
			{
				model.Image = model.Image;
			}
			else
			{
				try
				{
					string imageSave = helper.SaveAs(imagePath, imageFile);
					model.Image = imageSave;
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, "圖片上傳失敗: " + ex.Message);
				}

			}


			if (ModelState.IsValid == false) return View(model);

			UpdateVideoDto request = model.ToEditDto();

			try
			{
				_videoService.UpdateVideo(request);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}

			if (ModelState.IsValid == true)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View(model);
			}
		}
	}
}