using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

		public string GetStatus(int? status)
		{
			string msg;
			if (status.HasValue == false)
			{
				return msg = "所有";
			}
			else if (status.Value == 0)
			{
				return msg = "待處理";
			}
			else if (status.Value == 1)
			{
				return msg = "已結案";
			}
			else
			{
				return msg = "已取消";
		    };
		}
	}
}