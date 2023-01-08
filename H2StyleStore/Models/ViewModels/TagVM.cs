using H2StyleStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.ViewModels
{
	public class TagVM
	{

		public string TagName { get; set; }
	}

	public static class TagVMExts
	{
		public static TagVM ToVM(this TagDto source)
		{
			return new TagVM
			{
				TagName = source.TagName,
			};
		}
	}
}