using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{
	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class VideoController : ControllerBase
	{
		private VideoService _service;

		public VideoController(AppDbContext db)
		{
			_service = new VideoService(db);
		}
		// GET: api/<VideoController>
		[HttpGet()]
		public async Task<IEnumerable<VideoDTO>> GetVideos([FromQuery] string? keyword)
		{
			IEnumerable<VideoDTO> data = await _service.GetVideos(keyword);
			return data;
		}

		// GET api/<VideoController>/5  
		[HttpGet("{id}")]
		public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
		{
			return await _service.GetVideo(id); ;
		}

		//熱門影片
		//public async Task<IEnumerable<VideoDTO>> GetNews()
		//{
		//	//return await _service.GetNews();
		//}

		// GET api/<VideoController>/MyLike/5  
		[HttpGet("/MyLike/{id}")]
		public async Task<IEnumerable<VideoLikeDTO>> GetLikeVideos(int memberId)
		{
			return await _service.GetLikeVideos(memberId);
		}

		// POST api/<VideoController>/Like
		[HttpPost("Like")]
		public void PostLike(int memberId, int videoId)
		{ 
			_service.PostLike(memberId, videoId);
		}

		// POST api/<VideoController>/View/5
		[HttpPost("/View/{id}")]
		public void PostView(int videoId)
		{
			_service.PostView(videoId);
		}
	}
}
