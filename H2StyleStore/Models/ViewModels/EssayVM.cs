using H2StyleStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.ViewModels
{
	public class EssayVM
	{
		[Key]
		public int Essay_Id { get; set; }

		public int Influencer_Id { get; set; }

		public DateTime UplodTime { get; set; }

		[Required]
		[StringLength(1000)]
		public string ETitle { get; set; }

		[Required]
		[StringLength(1000)]
		public string EContent { get; set; }

		public DateTime UpLoad { get; set; }

		public DateTime Removed { get; set; }


	}
	public static class EssayDtoExts
	{
		public static EssayDTO ToVM(this EssayVM source)
		=> new EssayDTO
		{
			Essay_Id = source.Essay_Id,
			Influencer_Id = source.Influencer_Id,
			UplodTime = source.UplodTime,
			ETitle = source.ETitle,
			EContent = source.EContent,
			UpLoad= source.UpLoad,
			Removed = source.Removed,
		};
	}
}