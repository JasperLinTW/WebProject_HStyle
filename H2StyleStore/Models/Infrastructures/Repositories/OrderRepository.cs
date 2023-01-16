using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

		public void Update(OrderDTO entity)
		{
			Order order = _db.Orders.Find(entity.Order_id);

			var log = new Order_Log
			{
				Order_id = entity.Order_id,
				Status = entity.Status,
				Status_ChangedTime = DateTime.Now,
			};

			_db.Order_Log.Add(log);

			order.Status_id= entity.Status_id;
			order.ShippedDate = entity.ShippedDate;


			_db.SaveChanges();
		}

		public IEnumerable<Order_DetailDTO> FindById(int? id)
		{
			IEnumerable<Order_Details> order_detail = _db.Order_Details;
			var data = order_detail.Select(od => od.ToDTO());
			
			return data;
		}

		public IEnumerable<SelectListItem> GetStatus(int? status)
		{
			var items = _db.Order_Status.Select(x => new SelectListItem
			{
				Value = x.Status_id.ToString(),
				Text = x.Status,
				Selected = (status.HasValue && x.Status_id == status.Value)
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

		public OrderDTO GetOrderbyId(int id)
		{
			OrderDTO order = _db.Orders.Find(id).ToDTO();

			return order;
		}

		public IEnumerable<SelectListItem> GetStatus()
		{
			var items = _db.Order_Status.Where(x => x.Status_id != 6).Select(x => new SelectListItem
			{
				Value = x.Status_id.ToString(),
				Text = x.Status,
			})
			.ToList();

			return items;
		}

		public int StatusTransfer(string status)
		{
			var data = _db.Order_Status.FirstOrDefault(x => x.Status == status);
			int result = data.Status_id;

			return result;
		}

		public IEnumerable<SelectListItem> GetStatusDescription()
		{
			var items = _db.Order_StatusDescription.Where(x => x.Status_id == 6).Select(x => new SelectListItem
			{
				Value = x.Description_id.ToString(),
				Text = x.Description,
			})
			.ToList()
			.Prepend(new SelectListItem { Value = string.Empty, Text = "請選擇" });

			return items;
		}

		public void Cancel(int status_Description, int order_id)
		{
			Order order = _db.Orders.Find(order_id);

			var log = new Order_Log
			{
				Order_id = order_id,
				Status = "取消",
				Status_ChangedTime = DateTime.Now,
			};

			_db.Order_Log.Add(log);

			order.Status_Description_id= status_Description;
			if (status_Description < 6)
			{
				order.Status_id = 6;
			}

			_db.SaveChanges();

		}
	}
}