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

			//var data= await _db.Videos.Select(v => new VideoDTO
			//{
			//	Id = v.Id,
			//	Title = v.Title,
			//	CategoryId = v.CategoryId,
			//	ImageId= v.ImageId,
			//	CreatedTime = v.CreatedTime,
			//	Description = v.Description,
			//	FilePath = v.FilePath,
			//	OnShelffTime = v.OnShelffTime,
			//	OffShelffTime = v.OffShelffTime,
			//	Tags=v.Tags.Select(t=>t.TagName)
			//}). ToListAsync();
			return data;
		}

		public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
		{
			IEnumerable<VideoDTO> data = await _db.Videos.Where(x => x.Id == id).Select(v => v.ToVideoDTO()).ToListAsync();

			//var video= await _db.Videos.Where(v=>v.Id==id).Select(v => new VideoDTO
			//{
			//	Id = v.Id,
			//	Title = v.Title,
			//	CategoryId = v.CategoryId,
			//	ImageId = v.ImageId,
			//	//CreatedTime = v.CreatedTime,
			//	Description = v.Description,
			//	FilePath = v.FilePath,
			//	//OnShelffTime = v.OnShelffTime,
			//	//OffShelffTime = v.OffShelffTime,
			//	Tags = v.Tags.Select(t => t.TagName)
			//}).ToListAsync();

			if (data == null)
			{
				throw new Exception();
			}
			return data;
		}

		public void PostLike(VideoLikeDTO value)
		{
			VideoLike like = value.ToVideoLike();
			_db.VideoLikes.Add(like);
			_db.SaveChanges();
		}
	}
}
