using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;

namespace HStyleApi.Models.Services
{
	public class ProductServices
	{
		private readonly ProductRepo _repo;
		public ProductServices(AppDbContext db)
		{
			_repo = new ProductRepo(db);
		}

		public IEnumerable<ProductDto> LoadProducts()
		{
			var data = _repo.LoadProducts();
			return data;
		}

		public ProductDto GetProduct(int product_id)
		{
			var data = _repo.GetProduct(product_id);

			return data;

		}

		public IEnumerable<ProductDto> GetRecommend(int product_id, int member_id)
		{

			//若無登入或無購買紀錄就以目前瀏覽的商品有相同tag作為推薦

			//取得member有買過的商品資料
			var data = _repo.GetOrderProducts(member_id);

			//以member購買過的商品具相同tag作為推薦

			return null;

		}

		public (bool, string) CreateComment(PCommentPostDTO dto, int orderId, int productId)
		{
			//TODO驗證

			_repo.CreateComment(dto, orderId, productId);

			return (true, "新增成功");
		}

		public PCommentGetDTO GetComment(int productId, int orderId)
		{
			var data = _repo.GetComment(productId, orderId);

			return data;
		}

		public void HelpfulComment(int comment_id, int member_id)
		{
			_repo.HelpfulComment(comment_id, member_id);
		}

		public IEnumerable<PCommentDTO> LoadComments()
		{
			var data = _repo.LoadComments();
			return data;
		}

		public void LikesProduct(int product_id, int member_id)
		{
			_repo.LikesProduct(product_id, member_id);
		}

		public IEnumerable<Product_LikeDTO> LoadLikeProducts(int member_id)
		{
			var data = _repo.LoadLikeProducts(member_id);

			return data;
		}
	}
}
