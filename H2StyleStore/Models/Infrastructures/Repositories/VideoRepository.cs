using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
	public class VideoRepository : IVideoRepository
	{
		private readonly AppDbContext _db;

		public VideoRepository(AppDbContext db)
		{
			_db = db;
		}
		public IEnumerable<VideoDto> GetVideos()
		{
			IEnumerable<Video> query = _db.Videos;
			return query.Select(v => v.ToDto());
		}

		public void CreateVideo(VideoDto dto)
		{
			var video = new Video()
			{
				Id = dto.Id,
				Title = dto.Title,
				Description = dto.Description,
				FilePath = dto.FilePath,
				ImageId = dto.ImageId,
				OnShelffTime = dto.OnShelffTime,
				OffShelffTime = dto.OffShelffTime,
			};

			_db.Videos.Add(video);

			var db = new AppDbContext();
			Tag insertTag = db.Tags.FirstOrDefault(t => t.TagName);

			foreach ()
			{
				if (insertTag.IsExist)
				{
					Tag oldTag =
				}
				else
				{
					Tag newTag =
				}
			}

			_db.Videos.Add(video);
			_db.SaveChanges();
		}
	}
}