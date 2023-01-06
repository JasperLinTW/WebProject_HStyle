using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Models.Services
{
	public class OrderService
	{
		private readonly IOrderRepository _repository;
		public OrderService(IOrderRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<OrderDTO> Load()
		{
			return _repository.Load();
		}

		public IEnumerable<SelectListItem> GetStatus()
		{
			return _repository.GetStatus();
		}

		public Order_DetailDTO Find(int id)
		{
			return _repository.FindById(id);
		}
	}
}