using HStyleApi.Controllers;
using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace HStyleApi.Models.Services
{
	public class VideoService
	{
		private VideoRepository _videoRepository;

		public VideoService(HstyleStoreContext db)
		{
			_videoRepository = new VideoRepository(db);
		}

		public async Task <IEnumerable<VideoDTO>> GetVideos()
		{
			var data=_videoRepository.GetVideos();
			return await data;
		}

		public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
		{
			var data = _videoRepository.GetVideo(id);
			return await data;
		}

		public void PostLike(VideoLikeDTO value)
		{
			if (value == null)
			{
				throw new Exception();
			}else
			{
				_videoRepository.PostLike(value);
			}
		}
	}
}
