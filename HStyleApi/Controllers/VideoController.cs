using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

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
		public async Task<ActionResult<IEnumerable<VideoDTO>>> GetVideos([FromQuery] string? keyword)
		{
			
			try
			{
				IEnumerable<VideoDTO> data = await _service.GetVideos(keyword);
				return Ok(data);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET api/<VideoController>/5  
		[HttpGet("{id}")]
		public async Task<ActionResult<IEnumerable<VideoDTO>>> GetVideo(int id)
		{
			try
			{
				IEnumerable<VideoDTO> data = await _service.GetVideo(id);
				return Ok(data);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET api/<VideoController>/5  
		[HttpGet("{videoId}/Recommenations")]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetRecommendationProduct(int videoId)
		 {
			IEnumerable < ProductDto > products =await _service.GetRecommendationProduct(videoId);
			return Ok(products);
		}

		// GET api/<VideoController>/5 
		[HttpGet("News")]
		public async Task<ActionResult<IEnumerable<VideoDTO>>> GetNews()
		{
			try
			{
				IEnumerable<VideoDTO> data= await _service.GetNews();
				return Ok(data);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//GET api/<VideoController>/MyLike/5  
		[HttpGet("MyLike/{memberId}")]
		public async Task<IEnumerable<VideoLikeDTO>> GetLikeVideos(int memberId)
		{
			if (memberId == null)
			{
				throw new Exception("請先登入會員");
			}else
			{
				return await _service.GetLikeVideos(memberId);
			}
		}

		// POST api/<VideoController>/Like
		[HttpPost("Like")]
		public void PostLike(int memberId, int videoId)
		{ 
			if (memberId == null)
			{
				throw new Exception("請先登入會員");
			}else
			{
				_service.PostLike(memberId, videoId);
			}
		}

		// POST api/<VideoController>/View/5
		[HttpPost("View/{videoId}")]
		public void PostView(int videoId)
		{
			_service.PostView(videoId);
		}

		//GET api/<VideoController>/5 
		//GET 所有評論
		[HttpGet("Comments")]
		public async Task<IEnumerable<VideoCommentDTO>> GetComments( int videoId)
		{
			return await _service.GetComments(videoId);
		}

		//POST api/<VideoController>/Comment/5
		//POST 評論
		[HttpPost("Comment")]
		public void CreateComment([FromBody] string comment, int memberId, int videoId)
		{
			if (memberId == null)
			{
				throw new Exception("請先登入會員");
			}
			else
			{
				_service.CreateComment(comment, memberId, videoId);
			}
		}

		//POST api/<VideoController>/CommentLike
		[HttpPost("CommentLike")]
		public void PostCommentLike(int memberId,int CommentId)
		{
			if (memberId == null)
			{
				throw new Exception("請先登入會員");
			}
			else
			{
				_service.PostCommentLike(memberId, CommentId);
			}
		}
	}
}
