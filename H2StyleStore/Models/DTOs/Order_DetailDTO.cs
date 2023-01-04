using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.DTOs
{
	public class Order_DetailDTO
	{
		public int Order_id { get; set; }

		public int Product_id { get; set; }

		public string ProductName { get; set; }

		public int UnitPrice { get; set; }

		public int SubTotal { get; set; }

		public int Quantity { get; set; }

		public int? Discount { get; set; }
	}
}