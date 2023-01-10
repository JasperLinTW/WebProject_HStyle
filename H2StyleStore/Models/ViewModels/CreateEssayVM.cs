using H2StyleStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public string Influencer_Name { get; set; }

		[Required]
		[StringLength(10)]
		[Display(Name = "標題名稱")]
		public string ETitle { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "内文")] // 修改Html加入...
		public string EContent { get; set; }
		[Display(Name = "檔案上傳")]
		[Required]
		public string FilePath { get; set; }
		// 下拉
		[Display(Name = "類別名稱")]
		public int CategoryId { get; set; }

		[Display(Name = "設定發佈時間")]
		public DateTime UpLoad { get; set; }

		[Display(Name = "設定下架時間")]
		public DateTime Removed { get; set; }

		[Display(Name = "圖片")]
		public List<string> Images { get; set; }

		[Display(Name = "標籤")]
		public IEnumerable<string> Tags { get; set; }
	}

	public static class CreateEssayDTOExts
	{
		public static CreateEssayDTO ToCreateDTO(this CreateEssayVM source)
		{
			return new CreateEssayDTO
			{
				Essay_Id = source.Essay_Id,
				ETitle = source.ETitle,
				EContent = source.EContent,
				UpLoad = source.UpLoad,
				Removed = source.Removed,
				CategoryId = source.CategoryId,
			};
		}
	}
}