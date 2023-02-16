using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{
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
		public IEnumerable<ProductDto> LoadProducts()
		{
			var data = _Service.LoadProducts();
			return data;
		}

		// GET api/<ProductsController>/5
		[HttpGet("{product_id}")]
		public ProductDto GetProduct(int product_id)
		{
			var data = _Service.GetProduct(product_id);
			return data;
		}


		[HttpGet("{member_id/product_id}")]
		public ProductDto ProductRecommend(int product_id)
		{
			var data = _Service.GetProduct(product_id);
			return data;
		}

		// POST api/<ProductsController>
		[HttpPost]
		public void Post([FromBody] string value)
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
