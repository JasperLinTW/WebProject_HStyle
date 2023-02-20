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
			CheckoutDTO data = new CheckoutDTO
            {
                MemberId = _memberId,
                CartItems = new List<CheckoutItemsDTO>
                {
                    new CheckoutItemsDTO{ Quantity = 1, SpecId =1},
                    new CheckoutItemsDTO{ Quantity = 3, SpecId =3}
                },
                Payment = value.Payment,
                ShipVia= value.ShipVia,
                ShipName= value.ShipName,
                ShipPhone= value.ShipPhone,
                ShipAddress= value.ShipAddress,
                CreatedTime = DateTime.Now,
                StatusId = 1,
                StatusDescriptionId= 2,
                
            };
            data.Total = data.CartItems.Sum(x => x.Quantity * 1000);
            data.Freight = data.Total > 10000 ? 0 : 100;//todo換成變數

			return Ok(data);
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
        public CartListDTO Get(int memberId)
        {
            return _CartService.GetCart(memberId);
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public string Get()
        {
            return "value";
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
		[HttpPost("Minus/{specId}")]
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

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
