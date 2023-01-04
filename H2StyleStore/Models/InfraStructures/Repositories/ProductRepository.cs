using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _db;
		public ProductRepository(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<ProductDto> GetProducts()
		{
			IEnumerable<Product> query = _db.Products;
				//.Include("PCategory");
			
			query = query.OrderBy(x => x.DisplayOrder);

			return query.Select(x => x.ToDto());
		}

		public IEnumerable<SelectListItem> GetCategories()
		{
			var data = _db.PCategories;

			
			foreach (var item in data)
			{
				yield return new SelectListItem { Value = item.PCategory_Id.ToString(), Text = item.PCategoryName };
				
			}
			
		}
	}
}