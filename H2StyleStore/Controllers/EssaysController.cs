using H2StyleStore.Models;
using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace H2StyleStore.Controllers
{
	public class EssaysController : Controller
	{

		private EssayService essayService;
		private IEssayRepository essayRepository;

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

		//public ActionResult UploadEssay()
		//{
		//	ViewBag.PCategoryItems = new EssayRepository(new AppDbContext()).GetCategories();
		//	return View();
		//}

		/// <summary>
		/// create essay
		/// </summary>
		/// <returns></returns>
		public ActionResult NewEssay()
		{
			ViewBag.VideoCategoriesItems = new EssayRepository(new AppDbContext()).GetCategories();
			return View();
		}

		[HttpPost]
		public ActionResult NewEssay(CreateEssayVM model, HttpPostedFileBase[] files)
		{

			ViewBag.VideoCategoriesItems = new EssayRepository(new AppDbContext()).GetCategories();

			if (files[0] != null)
			{
				string path = Server.MapPath("/Images/EssayImages");
				var helper = new UploadFileHelper();


				foreach (var file in files)
				{
					try
					{
						string result = helper.SaveAs(path, file);
						//string OriginalFileName = System.IO.Path.GetFileName(file.FileName);
						string FileName = result;

					  model.Images.Add(FileName);
					}
					catch (Exception ex)
					{
						ModelState.AddModelError(string.Empty, "上傳檔案失敗: " + ex.Message);

					}
				}
			}

			try
			{
				CreateEssayDTO essayDTO = model.ToCreateDTO();
				(bool IsSuccess, string ErrorMessage) result = essayService.Create(essayDTO);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}

			if (ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}


			ViewBag.message = "Blog Datails Are Successfully..!";

			return View(model);
		}

	}
}