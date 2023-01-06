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
			var items = _db.Orders.Select(s => new SelectListItem
			source.Add(0, "待處理");
			source.Add(1, "已結案");
			source.Add(-1,"已取消");
			string msg = string.Empty;
			if (status == null)
			source.Add(0, "待處理");
			source.Add(1, "已結案");
			source.Add(-1,"已取消");
			string msg = string.Empty;
			if (status == null)
			source.Add(0, "待處理");
			source.Add(1, "已結案");
			source.Add(-1,"已取消");
			string msg = string.Empty;
			if (status == null)
			source.Add(0, "待處理");
			source.Add(1, "已結案");
			source.Add(-1,"已取消");
			string msg = string.Empty;
			if (status == null)
			source.Add(0, "待處理");
			source.Add(1, "已結案");
			source.Add(-1,"已取消");
			string msg = string.Empty;
			if (status == null)
			source.Add(0, "待處理");
			source.Add(1, "已結案");
			source.Add(-1,"已取消");
			string msg = string.Empty;
			if (status == null)
			{
				msg = "所有";
			}
			else
			{
				msg = source[status];
			};

			var items = _db.Orders.AsEnumerable().Select(o => new SelectListItem
			{
				Value = o.Status.ToString(),
				Text = msg,
				Selected = (status.HasValue && o.Status == status)
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