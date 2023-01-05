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
			var s = new Status()
			{
				Id = 1,
				status = "已處理"
			};

			var items = _db.Orders.AsEnumerable().Select(o => new SelectListItem
			{
				Value = s.Id.ToString(),
				Text = s.status,
				Selected = (status.HasValue && s.Id == status)
			})
			.ToList()
			.Prepend(new SelectListItem { Value = string.Empty, Text = "請選擇"});

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