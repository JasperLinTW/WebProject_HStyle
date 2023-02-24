using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

		public IEnumerable<ProductDto> GetOrderProducts(int member_id)
		{
			//此會員的所有訂單的商品Id
			var orderproductsId = _db.Orders
								.Include(o => o.OrderDetails)
								.Where(x => x.MemberId == member_id)
								.Select(x => x.OrderDetails.Select(x => x.ProductId));



			//var tags = _db.Tags.Include(x => x.Products);

			return null;

			


		}

		public Product GetProductInfo(int product_id)
		{
			var data = _db.Products.Include(x => x.Tags).Include(x => x.Specs)
								   .FirstOrDefault(x => x.ProductId == product_id);

			return data;

		}

		public List<int> GetProductByTags(IEnumerable<int> data, int product_id)
		{
			var products = _db.Products.Include(x => x.Tags).Where(x => x.ProductId != product_id);

			List<int> products_id = new List<int>();

			foreach (var item in products)
			{
				foreach (var tag in data)
				{
					if (item.Tags.Any(x => x.Id == tag) == true)
					{
						products_id.Add(item.ProductId);
					}
				}
			}
			return products_id;
		}

		public IEnumerable<ProductDto> GetProducts(List<int> recommendlist)
		{
			IEnumerable<Product> data = _db.Products
										.Include(product => product.Category)
										.Include(product => product.Imgs)
										.Include(product => product.Specs)
										.Include(product => product.Tags);

			List<ProductDto> source = new List<ProductDto>();

			foreach (var id in recommendlist)
			{
				var product = data.FirstOrDefault(x => x.ProductId == id).ToDto();

				source.Add(product);
			}

			return source;
		}

		public List<int> GetProductByColor(IEnumerable<string> colors, List<int> list_id)
		{
			var products = _db.Products.Include(x => x.Specs).Where(x => !list_id.Contains(x.ProductId));


			if (products == null)
			{
				return null;
			}

			List<int> products_id = new List<int>();

			foreach (var item in products)
			{
				foreach (var color in colors)
				{
					if (item.Specs.Any(x => x.Color.Contains(color.Replace("色", string.Empty)) == true))
					{
						products_id.Add(item.ProductId);
					}
				}
			}
			return products_id;
		}
	}
}
