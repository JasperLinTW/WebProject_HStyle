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
        public ActionResult Index()
        {
            var data = orderService.Load()
                       .Select(x => x.ToVM());
			return View(data);
        }
    }
}