using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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

		//影片列表：取出所有影片、篩選
		public async Task<IEnumerable<VideoDTO>> GetVideos(string? keyword)
		{
			IEnumerable<Video> data = await _db.Videos.Include(v => v.Image)
															.Include(v => v.Tags)
															.Include(v => v.VideoLikes)
															.Include(v => v.VideoView).Where(v=>v.IsOnShelff==true)
															.ToListAsync();
			if (data == null)
			{
					throw new Exception();
			}

			if (keyword == null)
			{
				return data.Select(x => x.ToVideoDTO()); ;
			}
			else
			{
				IEnumerable<VideoDTO> selectVideos = data.Where(v => v.Title.Contains(keyword)||v.Tags.Select(t=>t.TagName).Contains(keyword)).Select(x => x.ToVideoDTO());
				return selectVideos;
			}			
		}

		//單一影片資訊
		public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
		{
			IEnumerable<Video> data = await _db.Videos.Where(x => x.Id == id)
												.Include(v => v.Image) 
												.Include(v => v.Tags)
												.Include(v => v.VideoLikes)
												.Include(v => v.VideoView).Where(v => v.IsOnShelff == true)
												.ToListAsync();

			if (data == null)
			{
				throw new Exception();
			}

			IEnumerable<VideoDTO> video = data.Select(x => x.ToVideoDTO());

			return video;
		}

		//使用者收藏的影片
		public async Task <IEnumerable<VideoLikeDTO>> GetLikeVideos(int memberId)
		{
			IEnumerable<VideoLike> data = await _db.VideoLikes
												.Include(v => v.Video)
												.ThenInclude(v => v.Image)
												.Include(v=>v.Video)
												.ThenInclude(v=>v.Tags)
												.Include(v=>v.Video)
												.ThenInclude(v=>v.VideoView)
												.Where(v=>v.MemberId==memberId)
												.ToListAsync();
			//TODO isOnshelf
			IEnumerable<VideoLikeDTO> likeVideo = data.Select(v=>v.ToLikeDTO());
			return likeVideo;
		}

		//收藏影片
		public void PostLike(int memberId, int videoId)
		{
			var data = _db.VideoLikes.Where(v=>v.MemberId==memberId).FirstOrDefault(v => v.VideoId == videoId);
			if (data == null)
			{
				VideoLike like = new VideoLike
				{
					MemberId = memberId,
					VideoId = videoId,
				};
				_db.VideoLikes.Add(like);
			}
			else _db.VideoLikes.Remove(data);	
			_db.SaveChanges();
		}

		//瀏覽次數
		public void PostView(int videoId) 
		{
			var data = _db.VideoViews.Find(videoId);
			if (data == null)
			{
				VideoView view = new VideoView()
				{
					VideoId= videoId,
					Views= 1
				};
				_db.VideoViews.Add(view);
			}else
			{
				data.Views++;
			}
			_db.SaveChanges();
		}
	}
}
