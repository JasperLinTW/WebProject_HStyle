using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.ViewModels
{
	public class CreateVideoVM
	{
		public int Id { get; set; }

		[Display(Name = "影片名稱")]
		[ Required ]
		public string Title { get; set; }

		[Display(Name = "影片說明")]
		public string Description { get; set; }

		[Display(Name = "檔案上傳")]
		[Required]
		public string FilePath { get; set; }

		[Display(Name = "上架時間")]		
		public DateTime? OnShelffTime { get; set; }

		[Display(Name = "下架時間")]
		public DateTime? OffShelffTime { get; set; }

		[Display(Name = "影片縮圖")]
		[Required]
		public Image Image { get; set; }

		[Display(Name = "標籤")]
		public IEnumerable<TagVM> Tags { get; set; }

		[Display(Name = "影片類別")]
		[Required]
		public VideoCategoryVM CategoryName{ get; set; }
	}
}