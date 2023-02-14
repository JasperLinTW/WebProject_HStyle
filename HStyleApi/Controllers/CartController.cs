using HStyleApi.Models.EFModels;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{
    [Route("api/{memberId}/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _CartService;

        public CartController(HstyleStoreContext db)
        {
            _CartService = new CartService(db);
        }

        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartController>
        [HttpPost("{specId}")]
        public ActionResult Add([FromBody] int specId)
        {
            int memberId = 1;
            if (memberId <= 0)
            {
                return Unauthorized("請先登入帳戶");
            }
            try
            {
                _CartService.AddItem(memberId, specId, 1);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
