using H2StyleStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace H2StyleStore.Models.ViewModels
{
	public class EditVideoVM
	{
		public int Id { get; set; }

		[Display(Name = "影片名稱")]
		[Required]
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
		[FileExtensions(ErrorMessage = "只能上傳圖檔")]
		public string Image { get; set; }

		[Display(Name = "影片類別")]
		[Required]
		public int CategoryId { get; set; }

		[Display(Name = "標籤")]
		public string Tags { get; set; }
	}

	public static class VideoDtoExts
	{
		public static UpdateVideoDto ToEditDto(this EditVideoVM source)
		{
			return new UpdateVideoDto
			{
				Id = source.Id,
				Title = source.Title,
				Description = source.Description,
				FilePath = source.FilePath,
				OnShelffTime = source.OnShelffTime,
				OffShelffTime = source.OffShelffTime,
				Image = source.Image,
				CategoryId = source.CategoryId,
				Tags = source.Tags.Split(',').ToList(),
			};
		}
	}
}