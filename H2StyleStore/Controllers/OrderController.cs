using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index(int? status)
        {
            ViewBag.Status = orderService.GetStatus(status);
            var data = orderService.Load()
                       .Select(x => x.ToVM());

			if (status.HasValue)
			{
				data = data.Where(o => o.Status == status.Value);
			}

			return View(data.ToList());
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}