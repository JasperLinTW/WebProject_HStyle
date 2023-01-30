using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using System;
using System.Collections;
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

		[Display(Name = "員工賬號ID")]
		[Required]
		public string Influencer_Name { get; set; }

		[Display(Name = "發佈時間")]
		[Required]
		public DateTime UplodTime { get; set; }

		[Required]
		[StringLength(10)]
		[Display(Name = "標題名稱")]

		public string ETitle { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "内文")] // 修改Html加入...
		public string EContent { get; set; }


		[Required]
		[Display(Name = "類別名稱")]
		public string CategoryName { get; set; }

		[Required]
		[Display(Name = "設定發佈時間")]
		public DateTime UpLoad { get; set; }

		[Required]
		[Display(Name = "設定下架時間")]
		public DateTime Removed { get; set; }

		[Required]
		[Display(Name = "圖片")]
		public IEnumerable<string> Images { get; set; }

		[Required]
		[Display(Name = "標籤")]
		public IEnumerable<string> Tags { get; set; }
		public int CategoryId { get; set; }


	}
	public static class EssayDtoExts
	{
		public static EssayVM ToVM(this EssayDTO source)
			=> new EssayVM
			{
				Essay_Id = source.Essay_Id,
				Influencer_Name = source.Influencer_Name,
				UplodTime = source.UplodTime,
				ETitle = source.ETitle,
				EContent = source.EContent,
				CategoryName = source.CategoryName,
				CategoryId = source.CategoryId,
				UpLoad = source.UpLoad,
				Removed = source.Removed,
				Images = source.images,
				Tags = source.Tags
			};

		public static EssayDTO ToDto(this EssayVM source)
			=> new EssayDTO
			{
				Essay_Id = source.Essay_Id,
				Influencer_Name = source.Influencer_Name,
				UplodTime = source.UplodTime,
				ETitle = source.ETitle,
				EContent = source.EContent,
				CategoryName = source.CategoryName,
				CategoryId = source.CategoryId,
				UpLoad = source.UpLoad,
				Removed = source.Removed,
			};
	}
}