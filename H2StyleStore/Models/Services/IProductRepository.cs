using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2StyleStore.Models.Services
{
	public interface IProductRepository
	{
		IEnumerable<ProductDto> GetProducts();
		CreateProductDto GetProduct(int id);

		bool IsExist(string productName);
		bool EditIsExist(string productName, int id);

		void Create(ProductDto product);

		void Create(CreateProductDto product);

		void Edit(CreateProductDto dto);
	}
}
