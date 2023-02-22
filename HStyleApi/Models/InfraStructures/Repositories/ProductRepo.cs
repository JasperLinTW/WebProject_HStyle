using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.EntityFrameworkCore;

namespace HStyleApi.Models.InfraStructures.Repositories
{
	public class ProductRepo
	{
		private readonly AppDbContext _db;
		public ProductRepo(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<ProductDto> LoadProducts()
		{
			IEnumerable<Product> data = _db.Products
										.Include(product => product.Category)
										.Include(product => product.Imgs)
										.Include(product => product.Specs)
										.Include(product => product.Tags);

			var  products = data.OrderBy(x => x.DisplayOrder).Select(x => x.ToDto());

			return products;
		}

		public ProductDto GetProduct(int product_id)
		{
			if (_db.Products.Find(product_id) == null)
			{
				throw new Exception("查無此商品");
			}

			IEnumerable<Product> data = _db.Products.Include(product => product.Category)
										.Include(product => product.Imgs)
										.Include(product => product.Specs)
										.Include(product => product.Tags);

			var product = data.FirstOrDefault(x => x.ProductId == product_id).ToDto();
			
			return product;

		}

		public void CreateComment(PCommentPostDTO dto, int orderId, int productId)
		{
			
			ProductComment pcomment = new ProductComment
			{
				OrderId = orderId,
				ProductId = productId,
				CommentContent= dto.CommentContent,
				Score= dto.Score,
				CreatedTime = DateTime.Now,
			};


			_db.ProductComments.Add(pcomment);

			foreach (string path in dto.PcommentImgs)
			{
				Image image = new Image { Path = path, };
				pcomment.PcommentImgs.Add(image);
			}

			_db.SaveChanges();
		}

		public PCommentGetDTO GetComment(int productId, int orderId)
		{
			IEnumerable<Product> data = _db.Products.Include(product => product.Category)
										.Include(product => product.Imgs)
										.Include(product => product.Specs)
										.Include(product => product.Tags);
			var product = data.FirstOrDefault(x => x.ProductId == productId).ToDto();

			var orderDetail = _db.OrderDetails.Where(x => x.OrderId == orderId).FirstOrDefault(x => x.ProductId == productId);

			PCommentGetDTO comment = new PCommentGetDTO
			{
				ProductId = productId,
				OrderId = orderId,
				ProductName = product.Product_Name,
				ProductPhoto = product.Imgs.ToList()[0],
				Color = orderDetail.Color,
				Size= orderDetail.Size,
			};

			return comment;

		}

		public void HelpfulComment(int comment_id, int member_id)
		{
			var data = _db.PcommentsHelpfuls.Where(x => x.CommentId == comment_id).FirstOrDefault(x => x.MemberId == member_id);

			if (data == null)
			{
				PcommentsHelpful source = new PcommentsHelpful
				{
					CommentId = comment_id,
					MemberId = member_id
				};
				_db.PcommentsHelpfuls.Add(source);
			}
			else
			{
				_db.PcommentsHelpfuls.Remove(data);
			}

			_db.SaveChanges();
		}

		public IEnumerable<PCommentDTO> LoadComments()
		{
			IEnumerable<ProductComment> data = _db.ProductComments.Include(x => x.PcommentImgs)
				                                                  .Include(x => x.Product)
																  .Include(x => x.Order).ThenInclude(x => x.OrderDetails);
			
			var comments = data.Select(x => x.ToDto());	

			return comments;
		}

		public void LikesProduct(int product_id, int member_id)
		{
			var data = _db.ProductLikes.Where(x => x.ProductId == product_id).FirstOrDefault(x => x.MemberId == member_id);
			if (data == null)
			{
				ProductLike source = new ProductLike
				{
					ProductId = product_id,
					MemberId = member_id
				};
				_db.ProductLikes.Add(source);
			}
			else
			{
				_db.ProductLikes.Remove(data);
			}

			_db.SaveChanges();
		}

		public IEnumerable<Product_LikeDTO> LoadLikeProducts(int member_id)
		{
			IEnumerable<ProductLike> data = _db.ProductLikes.Include(x => x.Product).ThenInclude(x => x.Imgs)
				                                            .Where(x => x.MemberId == member_id);

			var productsLike = data.Select(x => x.ToDto());

			return productsLike;
		}

		public IEnumerable<OrderDetailsDTO> GetOrderProducts(int member_id)
		{
			//此會員的所有訂單
			var orders = _db.Orders.Include(x => x.OrderDetails).Where(x => x.MemberId == member_id).ToList(); 

			//回傳此會員
			
		}
	}
}
