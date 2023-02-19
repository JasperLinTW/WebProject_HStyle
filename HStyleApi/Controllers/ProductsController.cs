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
	public class ProductsController : ControllerBase
	{
		private readonly ProductServices _Service;

		public ProductsController(AppDbContext db)
		{
			_Service = new ProductServices(db);
		}


		// GET: api/<ProductsController>
		[HttpGet]
		public ActionResult<ProductDto> LoadProducts()
		{
			try
			{
				var data = _Service.LoadProducts();
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}

			return Ok("取得全部商品");
		}

		// GET api/<ProductsController>/5
		[HttpGet("{product_id}")]
		public ActionResult GetProduct(int product_id)
		{
			try
			{
				var data = _Service.GetProduct(product_id);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}


			return Ok("取得單一商品");
		}


		[HttpGet("{product_id}")]
		public ProductDto ProductRecommend(int product_id, [FromBody]int member_id)
		{
			var data = _Service.GetRecommend(product_id, member_id);

			return data;
		}

		// POST api/<ProductsController>
		[HttpPost]
		public ActionResult CreateComment([FromBody] string comment, int score, List<IFormFile> files)
		{
			
		}

		// PUT api/<ProductsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ProductsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
