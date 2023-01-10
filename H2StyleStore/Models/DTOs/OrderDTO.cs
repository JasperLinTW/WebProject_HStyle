using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.DTOs
{
	public class OrderDTO
	{
		public int Order_id { get; set; }

		public int Member_id { get; set; }

		public string MemberName { get; set; }

		public int? Employee_id { get; set; }

		public string EmployeeAccount { get; set; }

		public int Total { get; set; }

		public int Payment { get; set; }

		public DateTime? ShippedDate { get; set; }

		public string ShipVia { get; set; }

		public int Freight { get; set; }

		public string ShipName { get; set; }

		public string ShipAddress { get; set; }

		public string ShipPhone { get; set; }

		public DateTime? RequestRefundTime { get; set; }

		public bool RequestRefund { get; set; }

		public DateTime CreatedTime { get; set; }

		public int Status_id { get; set; }

		public int? Status_Description_id { get; set; }
		public string Status { get; set; }

		public string Status_Description{ get; set; }
	}

	public static class OrderExts
	{
		public static OrderDTO ToDTO(this Order source)
		{
			return new OrderDTO
			{
				Order_id = source.Order_id,
				Member_id = source.Member_id,
				MemberName = source.Member.Name,
				Employee_id = source.Employee_id,
				EmployeeAccount = source.Employee.Account,
				Total = source.Total,
				Payment = source.Payment,
				ShippedDate = source.ShippedDate,
				ShipVia = source.ShipVia,
				Freight = source.Freight,
				ShipName = source.ShipName,
				ShipAddress = source.ShipAddress,
				ShipPhone = source.ShipPhone,
				RequestRefundTime = source.RequestRefundTime,
				RequestRefund = source.RequestRefund,
				CreatedTime = source.CreatedTime,
				Status_id = source.Status_id,
				Status = source.Order_Status.Status,
				Status_Description_id= source.Status_Description_id,
				Status_Description = source.Order_Status.Order_StatusDescription.Description
			};
		}
	}
}