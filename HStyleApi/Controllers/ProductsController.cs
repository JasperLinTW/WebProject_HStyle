using H2StyleStore.Models.Infrastructures;
using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{
	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly ProductServices _Service;
		private readonly int _member_id;
		private readonly AppDbContext _db;

		public ProductsController(AppDbContext db)
		{
			_Service = new ProductServices(db);
			_db = db;
			_member_id = 1; //之後用Cookie取
		}

		[HttpGet("test")]
		public dynamic GetTags(int member_id)
		{
			var orders = _db.Orders.Where(x => x.MemberId == member_id);

			var productsId = orders.Select(x => x.OrderDetails.Select(x => x.ProductId)).ToArray();
			List<int> products = new List<int>();
			foreach (var order in productsId)
			{
				foreach (var pId in order)
				{
					products.Add(pId);
				}
			}
			var dbPro = _db.Products.Include(x => x.Tags);
			
			
			var tags = new List<int>();
			foreach (var product in products)
			{
				var ts = dbPro.Where(x => x.ProductId == product).SingleOrDefault().Tags;
				foreach (var t in ts)
				{
					tags.Add(t.Id);
				}
			}
			return tags;
			
		}

		// 商品總覽
		[HttpGet("products")]
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

		//單一商品頁
		[HttpGet("{product_id}")]
		public ActionResult GetProduct(int product_id)
		{
			try
			{
				var data = _Service.GetProduct(product_id);
				return Ok(data);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}


			
		}

		//商品收藏
		[HttpPost("product/like")]
		public ActionResult LikesProduct (int product_id)
		{
			_Service.LikesProduct(product_id, _member_id);
			return Ok();
		}

		//商品收藏瀏覽
		[HttpPost("products/likes")]
		public ActionResult LoadLikeProducts()
		{
			var data = _Service.LoadLikeProducts(_member_id);

			return Ok(data);
		}

		//商品專屬推薦(根據此商品特徵篩選) //用在你可能會喜歡(商品頁)
		[HttpGet("ProdRec/{product_id}")]
		public IEnumerable<ProductDto> ProductRecommend(int product_id)
		{
			var data = _Service.GetRecommendByProducts(product_id);

			return data;
		}

		//評論頁
		[HttpGet("comment")]
		public ActionResult GetComment(int orderId,  int productId)
		{

		    var data = _Service.GetComment(productId, orderId);

			return Ok(data);
		}

		//新增評論
		[HttpPost("comment")]
		public IActionResult CreateComment([FromForm] PCommentPostDTO comment, int orderId, int productId)
		{
			long size = comment.files.Sum(f => f.Length);
			string path = "../H2StyleStore/Images/PCommentImages/";

			comment.PcommentImgs = new List<string>();

			foreach (var file in comment.files)
			{
				try
				{
					if (file.Length > 0)
					{
						var helper = new UploadFileHelper();
						string result = helper.SaveAs(path, file);
						string FileName = result;
						comment.PcommentImgs.Add($"{FileName}");
					}
				}
				catch (Exception ex)
				{

					return BadRequest(ex.Message);
				}

			}
			var data = _Service.CreateComment(comment, orderId, productId);

			return Ok("新增成功");
		}

		//評論是否有幫助
		[HttpPost("helpfulComment")]
		public ActionResult HelpfulComment(int comment_id)
		{
			_Service.HelpfulComment(comment_id, _member_id);

			return Ok();
		}

		//所有評論瀏覽
		[HttpGet("comments")]
		public ActionResult<PCommentDTO> LoadComments()
		{
			try
			{
				var data = _Service.LoadComments();
				return Ok(data);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}

			
		}

	}
}
