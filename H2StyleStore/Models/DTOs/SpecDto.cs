using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.DTOs
{
	public class SpecDto
	{
		public int Id { get; set; }

		public int Product_Id { get; set; }

		public string Color { get; set; }

		public string Size { get; set; }

		public int Stock { get; set; }

		public virtual Product Product { get; set; }
	}

	public static class SpecExts
	{
		public static SpecDto ToDto(this Spec source)
		=> new SpecDto
		{
			Id= source.Id,
			Product_Id= source.Product_Id,
			Color= source.Color,
			Size= source.Size,
			Stock= source.Stock,
		};
	}
}