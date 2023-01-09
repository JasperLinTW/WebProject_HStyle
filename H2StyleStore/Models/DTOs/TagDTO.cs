using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.DTOs
{
	public class TagDTO
	{
		public int Id { get; set; }

		public string TagName { get; set; }
	}
	public static class TagExts
	{
		public static string ToDto(this Tag source)
		{

			return source.TagName;
		}
	}
}