using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace H2StyleStore.Models.ViewModels
{
	public class CreateEssayVM
	{
		[Key]
		public int Essay_Id { get; set; }

		// todo 登入自動輸入
		[Display(Name = "員工賬號ID")]
		public int Influencer_Id { get; set; }

		[Required]
		[StringLength(500)]
		[Display(Name = "標題名稱")]
		public string ETitle { get; set; }

		[Required]
		[Display(Name = "摘要")] // 修改Html加入...
		public string EContent { get; set; }

		// 下拉
		[Display(Name = "類別名稱")]
		public int CategoryId { get; set; }

		[Display(Name = "設定發佈時間")]
		[Column(TypeName = "datetime2")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
		public DateTime UpLoad { get; set; }

		[Display(Name = "設定下架時間")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
		public DateTime Removed { get; set; }

		[Display(Name = "圖片")]
		public List<string> Images { get; set; }

		[Display(Name = "標籤")]
		public string Tags { get; set; }
	}

	public static class CreateEssayDTOExts
	{
		public static CreateEssayDTO ToCreateDTO(this CreateEssayVM source)
		{
			return new CreateEssayDTO
			{
				Essay_Id = source.Essay_Id,
				Influencer_Id = 3,
				ETitle = source.ETitle,
				EContent = source.EContent,
				UpLoad = source.UpLoad,
				Removed = source.Removed,
				CategoryId = source.CategoryId,
				Images = source.Images,
				Tags = source.Tags.Split(',').Select(x => x.Trim()).ToList(),
			};
		}
		public static CreateEssayDTO ToCreateDTO(this Essay source)
		=> new CreateEssayDTO
		{
			Essay_Id = source.Essay_Id,
			Influencer_Id = 3,
			ETitle = source.ETitle,
			EContent = source.EContent,
			UpLoad = source.UpLoad,
			Removed = source.Removed,
			CategoryId = source.CategoryId,
			Images = source.Images.Select(x => x.Path).ToList(),
			Tags = source.Tags.Select(x => x.TagName).ToList(),

		};
		public static CreateEssayVM ToCreateVM(this CreateEssayDTO source)
			=> new CreateEssayVM
			{
				Essay_Id = source.Essay_Id,
				Influencer_Id = 3,
				ETitle = source.ETitle,
				EContent = source.EContent,
				UpLoad = source.UpLoad,
				Removed = source.Removed,
				CategoryId = source.CategoryId,
				Images = source.Images,
				Tags = string.Join(",", source.Tags),
			};
	}
}