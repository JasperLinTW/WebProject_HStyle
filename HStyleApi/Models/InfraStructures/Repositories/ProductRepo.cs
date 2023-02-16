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
			IEnumerable<Product> data = _db.Products.Include(product => product.Category)
										.Include(product => product.Imgs)
										.Include(product => product.Specs)
										.Include(product => product.Tags);
			var product = data.FirstOrDefault(x => x.ProductId == product_id).ToDto();

			return product;

		}
	}
}
