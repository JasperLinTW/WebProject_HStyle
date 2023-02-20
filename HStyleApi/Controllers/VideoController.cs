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
		private VideoRepository _VideoRepository;
		public VideoController(AppDbContext db)
		{
			 _service = new VideoService(db);
			_VideoRepository= new VideoRepository(db);
		}
		// GET: api/<VideoController>
		[HttpGet]
		public async Task<IEnumerable<VideoDTO>> GetVideos()
		{
			IEnumerable<VideoDTO> data = await _service.GetVideos();
			var like = _VideoRepository.GetLikes();
			
			return data;
		}

		// GET api/<VideoController>/5  
		[HttpGet("{id}")]
		public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
		{
			return await _service.GetVideo(id); ;
		}

		// POST api/<VideoController>
		[HttpPost]
		public void PostLike(int memberId, int videoId)
		{ 
			_service.PostLike(memberId, videoId);
		}

		// PUT api/<VideoController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<VideoController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
