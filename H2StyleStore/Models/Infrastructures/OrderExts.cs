using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Infrastructures
{
	public static class OrderExts
	{
		public static OrderDTO ToDTO(this Order entity)
		{
			return entity == null
				? null
				: new OrderDTO
				{
					Order_id = entity.Order_id,
					Member_id = entity.Member_id,
					MemberName = entity.Member.Name,
					Employee_id = entity.Employee_id,
					Total = entity.Total,
					Payment = entity.Payment,
					ShippedDate	= entity.ShippedDate,
					ShipVia = entity.ShipVia,
					Freight = entity.Freight,
					ShipName = entity.ShipName,
					ShipAddress = entity.ShipAddress,
					ShipPhone = entity.ShipPhone,
					RequestRefund = entity.RequestRefund,
					RequestRefundTime = entity.RequestRefundTime,
					CreatedTime = entity.CreatedTime,
					Status_id = entity.Status_id,
					Status = entity.Order_Status.Status,
					Status_Description_id = entity.Status_Description_id,
					Status_Description = entity.Order_Status.Order_StatusDescription.Description
				};
		}
	}
}