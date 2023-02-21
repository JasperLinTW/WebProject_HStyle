using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{
	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class HCoinController : ControllerBase
	{
		private HCoinService _service;
		public HCoinController(AppDbContext db)
		{
			_service = new HCoinService(db);
		}

		// GET: api/<HCoinController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<HCoinController>/5
		[HttpGet("CheckIn/{memberId}")]
		public async Task<IEnumerable<HCheckInDTO>> GetHCheckIn(int memberId)
		{
			return await _service.GetHCheckIn(memberId);
		}

		// POST api/<HCoinController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<HCoinController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<HCoinController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
