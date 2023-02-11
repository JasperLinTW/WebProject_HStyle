using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;

namespace HStyleApi.Models.Services
{
	public class ProductServices
	{
		private readonly ProductRepo _repo;
		public ProductServices(HstyleStoreContext db)
		{
			_repo = new ProductRepo(db);
		}

		public IEnumerable<ProductDto> Get()
		{
			var data = _repo.GetProducts();
			return data;
		}
	}
}
