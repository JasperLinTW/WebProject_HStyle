using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.ViewModels;
using Microsoft.Ajax.Utilities;
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
        {
            return new TagDto()
            {
                Id= source.Id,
                TagName= source.TagName
            };
        }

		public static TagDto ToDto(this TagVM source)
		{
			return new TagDto()
			{
				Id = source.Id,
				TagName = source.TagName
			};
		}
		public static string ToDto(this Tag source)
		{
			return source.TagName;
		}
}