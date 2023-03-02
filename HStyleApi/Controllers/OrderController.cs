using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
		private readonly AppDbContext _db;
		public OrderController(AppDbContext db)
		{
			_repo = new OrderRepo(db);
			_orderService = new OrderService(_repo);
			_db= db;
			_memberId = 1;//TODO從COOKIE取
		}
		// GET: api/<OrderController>
		[HttpGet]
		public IEnumerable<OrderDTO> Get()
		{
			var orders = _orderService.GetOrders(_memberId);
			return orders;
		}

		[HttpGet("/test")]
		public dynamic test()
		{
			var tags = new List<int> { 34, 36 };

			var products = _db.Products
				.Include(x => x.Tags)
				.Select(x => new
				{
					productId = x.ProductId,
					isRecomended = x.Tags.Select(x => x.Id)
				}).ToList().Where(x => x.isRecomended.Intersect(tags).Any());//.Select(x => x.productId);
			


			return products;
        }

		// GET api/<OrderController>/5
		[HttpGet("{id}")]
		public OrderDTO Get(int orderId)
		{
			var order = _orderService.GetOrder(orderId);
			return order;
		}

		

		
	}
}
