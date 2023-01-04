using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _db;

		public OrderRepository(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<OrderDTO> Load()
		{
			IEnumerable<Order> orders = _db.Orders;
			var data = orders.Select(o => o.ToDTO());

			return data;
		}
	}
}