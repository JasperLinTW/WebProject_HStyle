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
	}
}
