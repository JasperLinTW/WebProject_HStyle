using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Infrastructures.Repositories
{	
	public class H_Source_DetailRepository : IH_Source_DetailRepository
	{
		private AppDbContext _db;
		public H_Source_DetailRepository(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<H_Source_DetailDto> GetSource()
		{
			IEnumerable<H_Source_Details> detail = _db.H_Source_Details
				//.Include(d => d.Member)
				.OrderBy(d => d.Source_H_Id)
				.ToList();
			var data = detail.Select(d => d.ToDto());

			return data;
		}
	}
}