using H2StyleStore.filter;
using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using Microsoft.Win32;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace H2StyleStore.Controllers
{
	[AuthrizeHelper("2", "3")]
	public class OrderController : Controller
	{
		private OrderService orderService;

		public OrderController()
		{
			var db = new AppDbContext();
			IOrderRepository repo = new OrderRepository(db);
			this.orderService = new OrderService(repo);
		}

		// GET: Order
		public ActionResult Index(int? status_id, int? pageSize)
		{
			ViewBag.Status = orderService.GetStatus(status_id);
			List<SelectListItem> pageSizeList = new List<SelectListItem>
			{
			new SelectListItem{ Text = "5", Value = "5", Selected = pageSize == 5},
			new SelectListItem{ Text = "10", Value = "10", Selected = pageSize == 10},
			new SelectListItem{ Text = "15", Value = "15", Selected = pageSize == 15},
			};
			ViewBag.pageSizeList = pageSizeList;
			var data = orderService.Load()
				.Select(x => x.ToVM());

			return View(data);
		}


		public ActionResult PartialPage(int? status_id, string searchString, string sortOrder, int? page, int? pageSize)
		{

			ViewBag.Status_order = orderService.GetStatus();
			ViewBag.CreatetimeSortParm = sortOrder == "date" ? "date_desc" : "date";
			ViewBag.TotalSortParm = sortOrder == "total" ? "total_desc" : "total";

			var data = orderService.Load();

			//可排序
			switch (sortOrder)
			{

				case "date":
					data = data.OrderBy(o => o.CreatedTime);
					break;
				case "date_desc":
					data = data.OrderByDescending(o => o.CreatedTime);
					break;
				case "total":
					data = data.OrderBy(o => o.Total);
					break;
				case "total_desc":
					data = data.OrderByDescending(o => o.Total);
					break;
				default:
					data = data.OrderBy(o => o.Order_id);
					break;
			}


			//可篩選
			if (status_id.HasValue)
			{
				data = data.Where(s => s.Status_id == status_id.Value);
			}
			//可搜尋
			if (string.IsNullOrEmpty(searchString) == false)
			{
				data = data.Where(n => n.MemberName.Contains(searchString) || n.Order_id.ToString().Contains(searchString));
			}
			var list = data.Select(x => x.ToVM());

			//檢視頁數
			pageSize = pageSize ?? 10;
			int pageNumber = (page ?? 1);

			return PartialView(list.ToPagedList(pageNumber, (int)pageSize));
		}
		[HttpGet]
		public ActionResult Search(string key)
		{
			//參數key為使用者輸入在input的資訊
			var dataIds = orderService.Load()
				.Select(x => x.Order_id.ToString())
				.Where(x=> x.StartsWith(key))
				.Take(5).ToList(); //拿取前五筆資料配對的資料

			var dataNames = orderService.Load()
				.Select(x => x.MemberName)
				.Where(x => x.StartsWith(key))
				.Take(5).ToList(); //拿取前五筆資料配對的資料

			var data = dataIds.Union(dataNames);

			return Json(data.DefaultIfEmpty(), JsonRequestBehavior.AllowGet);
		}
		public ActionResult Details(int? id)
		{
			var data = orderService.FindById(id).Select(x => x.ToVM());
			if (id != null)
			{
				data = data.Where(od => od.Order_id == id);
			}

			return View(data);
		}

		[HttpPost]
		public ActionResult Update(OrderUpdateVM[] orders)
		{
			try
			{
				for (int i = 0; i < orders.Length; i++)
				{
					orders[i].EmployeeAccount = this.User.Identity.Name;
					var status_id = orderService.StatusTransfer(orders[i].Status);
					orders[i].Status_id = status_id;
					orderService.Update(orders[i].ToDTO());
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, "修改失敗: " + ex.Message);
			}
			if (ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}

			return RedirectToAction("Index");


		}
		public ActionResult Edit(int id)
		{
			ViewBag.Status_order = orderService.GetStatus();
			ViewBag.StatusDescription = orderService.GetStatusDescription();
			var data = orderService.GetOrderbyId(id).ToVM();

			return View(data);
		}

		[HttpPost]
		public ActionResult Edit(OrderVM order)
		{
			try
			{
				order.EmployeeAccount = this.User.Identity.Name;
				orderService.Update(order.ToDTO());
			}
			catch (Exception ex)
			{

				ModelState.AddModelError(string.Empty, "修改失敗: " + ex.Message);
			}
			if (ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}

			return View(order);

		}

		[HttpPost]
		public string Cancel(int status_Description, int order_id)
		{

			try
			{
				orderService.Cancel(status_Description, order_id);
			}
			catch (Exception ex)
			{

				return "取消訂單失敗，原因:" + ex.Message;
			}
			return "取消訂單成功";


		}
        [HttpPost]
        private void SendMail(int status_Description, int order_id)
		{ 
			var member = orderService.GetMember(order_id);
			var content = orderService.GetCancelDescription(status_Description);
			MailMessage msg = new MailMessage();
            //收件者，以逗號分隔不同收件者 ex "test@gmail.com,test2@gmail.com"
            msg.From = new MailAddress("h11830123@gmail.com", "測試郵件", System.Text.Encoding.UTF8);
            //郵件標題 
            msg.Subject = $"您於H'style購買的訂單#{order_id}已遭取消";
            //郵件標題編碼  
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //郵件內容
            msg.Body = $"訂單取消原因:{content}，如有疑慮請來電客服，若造成您的不便敬請見諒！";
            msg.IsBodyHtml = true;
            msg.BodyEncoding = System.Text.Encoding.UTF8;//郵件內容編碼 
            msg.Priority = MailPriority.Normal;//郵件優先級 
                                               //建立 SmtpClient 物件 並設定 Gmail的smtp主機及Port 
            SmtpClient MySmtp = new SmtpClient("smtp-relay.gmail.com", 587);

            //設定你的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential("h11830123@gmail.com", "qkkhnbtngmerzzvl");
            //Gmial 的 smtp 使用 SSL
            MySmtp.EnableSsl = true;
            MySmtp.Send(msg);
        }

	}
}