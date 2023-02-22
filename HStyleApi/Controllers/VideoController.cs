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
		[HttpGet]
		public async Task<IEnumerable<VideoDTO>> GetVideos()
		{
			IEnumerable<VideoDTO> data =_service.GetVideos();
			return data;
		}

		// GET api/<VideoController>/5  
		[HttpGet("{id}")]
		public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
		{
			return await _service.GetVideo(id); ;
		}

		// GET api/<VideoController>/Like/5  
		[HttpGet("/Like/{id}")]
		public async Task<IEnumerable<VideoDTO>> GetLikeVideos(int id)
		{
			return await _service.GetLikeVideos(id); ;
		}

		// POST api/<VideoController>
		[HttpPost]
		public void PostLike(int memberId, int videoId)
		{ 
			_service.PostLike(memberId, videoId);
		}

		// POST api/<VideoController>/5
		[HttpPost]
		public void PostView(int videoId)
		{
			_service.PostView(videoId);
		}

		// PUT api/<VideoController>/5
		[HttpPut("{id}")]
		public void PutView(int id, [FromBody] string value)
		{

		}

		// DELETE api/<VideoController>/5
		[HttpDelete("{id}")]
		public void DeleteLike(int id)
		{

		}
	}
}
