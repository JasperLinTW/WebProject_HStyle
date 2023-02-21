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
    public class CartController : ControllerBase
    {
        private readonly CartService _CartService;
        private readonly CartRepo _repo;
        private readonly int _memberId;
        public CartController(AppDbContext db)
        {
            _repo= new CartRepo(db);
            _CartService = new CartService(_repo);
			_memberId = 1;//TODO從COOKIE取
		}
        [HttpPost("Checkout")]
        public IActionResult Checkout(CheckoutDTO value)
        {
			OrderDTO checkoutList = _CartService.GetCheckout(_memberId, value);

			_CartService.CreateOrder(checkoutList);

			return Ok("訂單完成");
        }

        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file)
        {
            string basePath = "https://localhost:44313/Images/";
            using (var stream = System.IO.File.Create(basePath + file.Name))
            {
                file.CopyTo(stream);
            }
            return Ok("新增成功");
        }


        // GET: api/<CartController>
        [HttpGet]
        public CartListDTO Get()
        {
            return _CartService.GetCart(_memberId);
        }

        

        // POST api/<CartController>
        [HttpPost("{specId}")]
        public ActionResult Add(int specId)
        {
            
            if (_memberId <= 0)
            {
                return Unauthorized("請先登入帳戶");
            }
            try
            {
                _CartService.AddItem(_memberId, specId, 1);

            }catch(Exception ex)
            {
                return BadRequest("商品缺貨中");
            }
            
            return Ok("新增成功");
        }
		[HttpDelete("{specId}")]
		public ActionResult Minus(int specId)
		{

			if (_memberId <= 0)
			{
				return Unauthorized("請先登入帳戶");
			}
			try
			{
				_CartService.MinusItem(_memberId, specId, 1);

			}
			catch (Exception ex)
			{
				return BadRequest("商品已不存在");
			}

			return Ok("刪除成功");
		}

		// PUT api/<CartController>/5
		[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       
    }
}
