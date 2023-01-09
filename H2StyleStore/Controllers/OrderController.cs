using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Controllers
{
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
        public ActionResult Index(string status, string value)
        {
            ViewBag.Status = orderService.GetStatus();
			ViewBag.Value = value;

			var data = orderService.Load()
                       .Select(x => x.ToVM());

            //依訂單成立時間排序
            data.OrderBy(x => x.CreatedTime);

            //可篩選
			if (string.IsNullOrEmpty(status) == false)
            {
				data = data.Where(s => s.Status == status);
			}
			//可搜尋
			if (string.IsNullOrEmpty(value) == false)
			{
				data = data.Where(n => n.MemberName.Contains(value) || n.Order_id.ToString().Contains(value));
			}

			return View(data);
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
			ViewBag.Status = statusSource();

			var data = orderService.Load()
					   .Select(x => x.ToVM());
			data.OrderBy(x => x.CreatedTime);
			return View(data.ToArray());
		}

        [HttpPost]
        public ActionResult Update(OrderVM[] orders)
        {
            for (int i = 0; i < orders.Length; i++)
            {
                orderService.Update(orders[i].ToDTO());
			}
            return RedirectToAction("Index");
        }

		public ActionResult Edit(int id)
		{
			ViewBag.Status = statusSource();
			var data = orderService.GetOrderbyId(id).ToVM();
			

			return View(data);
		}

		[HttpPost]
		public ActionResult Edit(OrderVM order)
		{
			orderService.Update(order.ToDTO());
			return RedirectToAction("Index");
		}

		public Dictionary<int, string> statusSource()
		{
			return new Dictionary<int, string>(){
				{ 0, "待處理" },
				{ 1, "備貨中" },
				{ 2, "已出貨" },
				{ 3, "已結案" },
				{ 4, "已取消" }
			};
		}
	}
}