using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EssayController : ControllerBase
	{
		private EssayService _service;

		public EssayController(AppDbContext db)
		{
			_service= new EssayService(db);
		}
		// GET: api/<EssayController>
		[HttpGet()]
		//FromQuery  =傳value篩選 代 service rpst
		public async Task<IEnumerable<EssayDTO>> GetEssays([FromQuery]  string keyword)
		{
			IEnumerable<EssayDTO> data = await _service.GetEssays(keyword);
			return data;
		}

		// GET api/<EssayController>/5
		[HttpGet("{id}")]
		public async Task<IEnumerable<EssayDTO>> GetEssay(int id)
		{
			
			return await _service.GetEssays(id);
		}

		//[HttpGet("News")]

		

		// GET api/<EssayController>/EssayLike/5
		[HttpGet("/Elike/{id}")]
		public async Task<IEnumerable<EssayLikeDTO>> GetlikeEssays(int memberId)
		{
			return await _service.GetlikeEssays(memberId);
		}
		// POST api/<EssayController>
		[HttpPost("Elike")]
		public void PostELike(int memberId, int essayId)
		{
			_service.PostELike(memberId, essayId);
		}

        //GET api/<VideoController>/5 
        //GET 所有評論
        [HttpGet("Comments")]
        public async Task<IEnumerable<EssayLikeDTO>> GetComments(int memberId)

        // PUT api/<EssayController>/5
        [HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<EssayController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
