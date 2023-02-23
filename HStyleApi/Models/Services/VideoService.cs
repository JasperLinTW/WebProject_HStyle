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

		public VideoService(AppDbContext db)
		{
			_videoRepository = new VideoRepository(db);
		}

		public async Task<IEnumerable<VideoDTO>> GetVideos(string? keyword)
		{
			var data = await _videoRepository.GetVideos(keyword);
			return data;
		}

		public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
		{
			var data = _videoRepository.GetVideo(id);
			return await data;
		}

		public async Task<IEnumerable<VideoLikeDTO>> GetLikeVideos(int memberId)
		{
			var data = await _videoRepository.GetLikeVideos(memberId);
			return  data;
		}

		public void PostLike(int memberId, int videoId)
		{
			if (memberId == 0 || videoId == 0) throw new Exception();
			else _videoRepository.PostLike(memberId, videoId);
		}

		public void PostView(int videoId)
		{
			_videoRepository.PostView(videoId);
		}
	}
}
