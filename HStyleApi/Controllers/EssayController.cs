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
		public async Task<IEnumerable<EssayDTO>> GetEssays()
		{
			return await _service.GetEssays();
		}

		// GET api/<EssayController>/5
		[HttpGet("{id}")]
		public async Task<IEnumerable<EssayDTO>> GetEssays(int id)
		{
			var Essay = await _service.GetEssays(id);
			if(Essay == null)
			{
				return NotFound();
			}
			return Essay;
		}

		// POST api/<EssayController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
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
