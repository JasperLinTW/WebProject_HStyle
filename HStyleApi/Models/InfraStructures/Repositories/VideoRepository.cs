using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HStyleApi.Models.InfraStructures.Repositories
{
	public class VideoRepository
	{
		private AppDbContext _db;

		public VideoRepository(AppDbContext db)
		{
			_db = db;
		}

		public async Task<IEnumerable<VideoDTO>> GetVideos()
		{
			var data = await _db.Videos.Select(v => v.ToVideoDTO()).ToListAsync();
			return data;
		}

		public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
		{
			IEnumerable<VideoDTO> data = await _db.Videos.Where(x => x.Id == id).Select(v => v.ToVideoDTO()).ToListAsync();
			if (data == null)
			{
				throw new Exception();
			}
			return data;
		}

		public int GetVideoLikes()
		{
			var likes = _db.VideoLikes.OrderBy(x => x.Id).Count();
			return likes;
		}

		public int GetVideoLike(int id)
		{
			var likes = _db.VideoLikes.Where(x=>x.VideoId==id).OrderBy(x=>x.Id).Count();
			return likes;
		}

		public void PostLike(int memberId,int videoId)
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
