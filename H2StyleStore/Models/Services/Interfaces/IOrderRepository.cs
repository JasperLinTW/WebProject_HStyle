using H2StyleStore.Models.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace H2StyleStore.Models.Services.Interfaces
{
	public interface IOrderRepository
	{
		IEnumerable<OrderDTO> Load();

		IEnumerable<SelectListItem> GetStatus(int? status);
	}
}
