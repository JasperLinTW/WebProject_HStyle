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
		[HttpGet]
		//FromQuery  =傳value篩選 代 service rpst
		public async Task<IEnumerable<EssayDTO>> GetEssays([FromQuery]  string keyword)
		{
			return await _service.GetEssays(keyword);
		}

		// GET api/<EssayController>/5
		[HttpGet("{id}")]
		public async Task<IEnumerable<EssayDTO>> GetEssay(int id)
		{
			
			return await _service.GetEssays(id);
		}

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
