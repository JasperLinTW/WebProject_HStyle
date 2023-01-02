using H2StyleStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.ViewModels
{
	public class ProductVM
	{
		public int Product_Id { get; set; }

		[Display(Name ="商品名稱")]
		public string Product_Name { get; set; }

		[Display(Name = "單價")]
		public int UnitPrice { get; set; }

		[Display(Name = "商品描述")]
		public string Description { get; set; }

		[Display(Name = "庫存量")]
		public int Stock { get; set; }

		[Display(Name = "創建時間")]
		public DateTime Create_at { get; set; }

		[Display(Name = "已下架")]
		public bool Discontinued { get; set; }

		[Display(Name = "類別名稱")]
		public string PCategoryName { get; set; }
	}

	public static class ProductDtoExts
	{
		public static ProductVM ToVM(this ProductDto source)
		=> new ProductVM
		{
			Product_Id = source.Product_Id,
			Product_Name = source.Product_Name,
			UnitPrice = source.UnitPrice,
			Description = source.Description,
			Stock = source.Stock,
			Create_at = source.Create_at,
			Discontinued = source.Discontinued,
			PCategoryName = source.PCategory.PCategoryName,
		};
	}
}