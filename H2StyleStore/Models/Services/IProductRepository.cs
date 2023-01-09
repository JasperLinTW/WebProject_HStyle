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

		bool IsExist(string productName);

		void Create(ProductDto product);

		void Create(CreateProductDto product);
	}
}
