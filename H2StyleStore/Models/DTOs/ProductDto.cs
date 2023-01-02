using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.DTOs
{
	public class ProductDto
	{
		public int Product_Id { get; set; }

		public string Product_Name { get; set; }

		public int UnitPrice { get; set; }

		public string Description { get; set; }

		public int Stock { get; set; }

		public DateTime Create_at { get; set; }

		public bool Discontinued { get; set; }

		public int DisplayOrder { get; set; }

		public PCategoryDto PCategory { get; set; }
	}

	public static class ProductExts
	{
		public static ProductDto ToDto(this Product source)
		=> new ProductDto
		{
			Product_Id = source.Product_Id,
			Product_Name = source.Product_Name,
			UnitPrice = source.UnitPrice,
			Description = source.Description,
			Stock = source.Stock,
			Create_at = source.Create_at,
			Discontinued = source.Discontinued,
			DisplayOrder = source.DisplayOrder,
			PCategory = source.PCategory.ToDto(),
		};
	}
}