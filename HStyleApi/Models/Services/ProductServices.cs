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

		public ProductDto GetRecommend(int product_id, int member_id)
		{

			//若無登入或無購買紀錄就以目前瀏覽的商品有相同tag作為推薦

			//取得member有買過的商品資料

			//以member購買過的商品具相同tag作為推薦

			return null;

		}

		public (bool, string) CreateComment(PCommentPostDTO dto)
		{
			//TODO驗證

			_repo.CreateComment(dto);

			return (true, "新增成功");
		}
	}
}
