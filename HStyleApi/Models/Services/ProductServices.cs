using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;

namespace HStyleApi.Models.Services
{
	public class ProductServices
	{
		private readonly ProductRepo _repo;
		private readonly AppDbContext _db;
		public ProductServices(AppDbContext db)
		{
			_repo = new ProductRepo(db);
			_db = db;
		}

		public IEnumerable<ProductDto> LoadProducts()
		{
			var data = _repo.LoadProducts();
			return data;
		}

		public ProductDto GetProduct(int product_id)
		{
			if (_db.Products.Find(product_id) == null)
			{
				throw new Exception("查無此商品");
			}
			else
			{
				var data = _repo.GetProduct(product_id);
				return data;
			}
			
		}
	}
}
