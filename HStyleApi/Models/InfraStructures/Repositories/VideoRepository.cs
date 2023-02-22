using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace HStyleApi.Models.InfraStructures.Repositories
{
	public class VideoRepository
	{
		private AppDbContext _db;

		public VideoRepository(AppDbContext db)
		{
			_db = db;
		}

		//影片列表：取出所有影片
		public async Task<IEnumerable<VideoDTO>> GetVideos()
		{
			IEnumerable<Video> data =await _db.Videos.Include(v => v.Title)
												.Include(v => v.ImageId)
												.Include(v => v.CategoryId)
												.Include(v => v.Tags)
												.Include(v => v.VideoLikes)
												.Include(v => v.VideoView).ToListAsync();

			if (data == null)
			{
				throw new Exception();
			}

			IEnumerable<VideoDTO> videos= data.Select(x=>x.ToVideoDTO());
			return videos;
		}

		//單一影片資訊
		public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
		{
			IEnumerable<Video> data = await _db.Videos.Where(x => x.Id == id)
												.Include(v => v.Title)
												.Include(v => v.ImageId)
												.Include(v => v.CategoryId)
												.Include(v => v.Tags)
												.Include(v => v.VideoLikes)
												.Include(v => v.VideoView)
												.Include(v => v.FilePath)
												.Include(v => v.Description).ToListAsync();

			if (data == null)
			{
				throw new Exception();
			}

			IEnumerable<VideoDTO> video = data.Select(x => x.ToVideoDTO());

			return video;
		}

		//使用者收藏的影片
		public async Task <IEnumerable<VideoLikeDTO>> GetLikeVideos(int id)
		{
			IEnumerable<Video> data = await _db.Videos
												.Include(v => v.Title)
												.Include(v => v.ImageId)
												.Include(v => v.CategoryId)
												.Include(v => v.Tags)
												.Include(v => v.VideoLikes)
												.Include(v => v.VideoView).ToListAsync();

			IEnumerable<VideoDTO> likeVideos = data.Where(x => x.MemberId == id).Select(x => x.ToLikeDTO());
			return likeVideos;
		}

		public void PostLike(int memberId, int videoId)
		{
			VideoLike like = new VideoLike
			{
				MemberId = memberId,
				VideoId = videoId,
				CreatedTime = DateTime.Now,
			};

			_db.VideoLikes.Add(like);
			_db.SaveChanges();
		}
	}
}
