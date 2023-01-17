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
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Controllers
{
	[AuthrizeHelper("2", "3")]
	public class OrderController : Controller
	{
		private OrderService orderService;

		public OrderController()
		{
			//string currentUser = this.User.Identity.Name;

			var db = new AppDbContext();
			IOrderRepository repo = new OrderRepository(db);
			//this.orderService = new OrderService(repo, currentUser);
			this.orderService = new OrderService(repo);
		}

		// GET: Order
		public ActionResult Index(int? status_id, string searchString, string sortOrder, string currentFilter, int? page)
		{
			ViewBag.Status = orderService.GetStatus(status_id);
			ViewBag.Value = searchString;
			ViewBag.Status_order = orderService.GetStatus();
			ViewBag.CurrentSort = sortOrder;
			ViewBag.CreatetimeSortParm = sortOrder == "Date" ? "date_desc" : "Date";
			ViewBag.TotalSortParm = sortOrder == "total" ? "total_desc" : "total";

			var data = orderService.Load();

			//可排序
			switch (sortOrder)
			{

				case "Date":
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
			//分頁
			if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			ViewBag.CurrentFilter = searchString;

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

			int pageSize = 3;
			int pageNumber = (page ?? 1);

			return View(list.ToPagedList(pageNumber, pageSize));
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

		public ActionResult Update()
		{
			ViewBag.Status = orderService.GetStatus();

			var data = orderService.Load()
					   .Select(x => x.ToVM());
			data.OrderBy(x => x.CreatedTime);
			return View(data.ToArray());
		}

		[HttpPost]
		public ActionResult Update(OrderUpdateVM[] orders)
		{
			for (int i = 0; i < orders.Length; i++)
			{
				var status_id = orderService.StatusTransfer(orders[i].Status);
				orders[i].Status_id = status_id;
				orderService.Update(orders[i].ToDTO());
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
			orderService.Update(order.ToDTO());
			return RedirectToAction("Index");
		}

		[HttpPost]
		public string Cancel (int status_Description, int order_id)
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

	}
}