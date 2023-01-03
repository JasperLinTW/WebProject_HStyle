using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.DTOs
{
	public class TagDto
	{
		public int Id { get; set; }

		public string TagName { get; set; }
	}
	public static class TagExts
	{
		public static TagDto ToDto(this Tag source)
		=> new TagDto
		{
			Id = source.Id,
			TagName = source.TagName,
		};
	}
}