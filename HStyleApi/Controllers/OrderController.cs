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
	public class OrderController : ControllerBase
	{
		private readonly OrderService _orderService;
		private readonly OrderRepo _repo;
		private readonly int _memberId;
		public OrderController(AppDbContext db)
		{
			_repo = new OrderRepo(db);
			_orderService = new OrderService(_repo);
			_memberId = 1;//TODO從COOKIE取
		}
		// GET: api/<OrderController>
		[HttpGet]
		public IEnumerable<OrderDTO> Get()
		{
			var orders = _orderService.GetOrders(_memberId);
			return orders;
		}

		// GET api/<OrderController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<OrderController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<OrderController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<OrderController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
