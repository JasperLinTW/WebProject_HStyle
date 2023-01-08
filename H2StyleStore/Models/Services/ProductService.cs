using H2StyleStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Services
{
	public class ProductService
	{
		private readonly IProductRepository _repository;

		public ProductService(IProductRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<ProductDto> GetProducts()
		{
			return _repository.GetProducts();
		}

		public (bool, string ) Create(ProductDto dto)
		{
			if (_repository.IsExist(dto.Product_Name))
			{
				return (false, "商品名稱已使用，請更改名稱");
			}

			_repository.Create(dto);

			return (true, null);

		}
	}
}