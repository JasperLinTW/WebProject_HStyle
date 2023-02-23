using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{
	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class MemberController : ControllerBase
	{
        private readonly MemberServices _Service;

        public MemberController(AppDbContext db)
        {
            _Service = new MemberServices(db);
        }
        // GET: api/<MemberController>
        [HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

        [HttpGet]
        public async Task<IEnumerable<MemberDTO>> GetMember() //text Get
        {
            return await _Service.GetMember();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
        {
            return await _Service.GetMember(id); ;
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<MemberController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<MemberController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<MemberController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
