using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.ViewModels
{
	public class OrdersVM
	{
		public int Order_id { get; set; }

		public int Member_id { get; set; }

		public int Employee_id { get; set; }

		public int Total { get; set; }

		public int Payment { get; set; }

		public DateTime? ShippedDate { get; set; }

		public int ShipVia { get; set; }

		public int Freight { get; set; }

		[Required]
		[StringLength(10)]
		public string ShipName { get; set; }

		[Required]
		[StringLength(60)]
		public string ShipAddress { get; set; }

		[Required]
		[StringLength(10)]
		public string ShipPhone { get; set; }

		public DateTime? RequestRefundTime { get; set; }

		public bool RequestRefund { get; set; }

		public DateTime CreatedTime { get; set; }

		public int Status { get; set; }
	}
}