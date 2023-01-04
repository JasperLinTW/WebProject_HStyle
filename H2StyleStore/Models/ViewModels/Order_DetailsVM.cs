using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.ViewModels
{
	public class Order_DetailsVM
	{
		[DisplayName("訂單編號")]
		public int Order_id { get; set; }
		[DisplayName("商品編號")]
		public int Product_id { get; set; }

		[Required]
		[StringLength(50)]
		[DisplayName("商品名稱")]
		public string ProductName { get; set; }

		[DisplayName("單價")]
		public decimal UnitPrice { get; set; }

		[DisplayName("小計")]
		public decimal SubTotal { get; set; }

		[DisplayName("數量")]
		public int Quantity { get; set; }

		[DisplayName("折扣")]
		public decimal? Discount { get; set; }
	}
}