using H2StyleStore.Models.Infrastructures;
using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting.Server;
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


		//[HttpGet("ProdRec/{product_id}")]
		//public ProductDto ProductRecommend(int product_id, [FromBody]int member_id)
		//{
		//	var data = _Service.GetRecommend(product_id, member_id);

		//	return data;
		//}

		[HttpGet("Comment")]
		public ActionResult GetComment( int orderId,  int productId)
		{

		    var data = _Service.GetComment(productId, orderId);

			return Ok(data);
		}

		[HttpPost("Comment")]
		public async Task<IActionResult> CreateComment([FromForm]PCommentPostDTO comment,int orderId, int productId)
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
