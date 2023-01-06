using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _db;

		public OrderRepository(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<SelectListItem> GetStatus(int? status)
		{

			Dictionary<int, string> source = new Dictionary<int, string>();
			source.Add(0, "待處理");
			source.Add(1, "已結案");
			source.Add(-1, "已取消");
			var items = source.Select(x => new SelectListItem
			{
				Value = x.Key.ToString(),
				Text = x.Value,
				Selected = (status.HasValue && x.Key == status)
			})
			.ToList()
			.Prepend(new SelectListItem { Value = string.Empty, Text = "所有" });

			return items;
		}

		public IEnumerable<OrderDTO> Load()
		{
			IEnumerable<Order> orders = _db.Orders;
			var data = orders.Select(o => o.ToDTO());

			return data;
		}
	}
}