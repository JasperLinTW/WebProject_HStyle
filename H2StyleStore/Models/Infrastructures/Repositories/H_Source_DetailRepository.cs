using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Infrastructures.Repositories
{	
	public class H_Source_DetailRepository
	{
		private AppDbContext _db;
		public H_Source_DetailRepository()
		{
			_db= new AppDbContext();
		}

		public IEnumerable<H_Source_DetailDto> GetSource()
		{
			// todo Include
			IEnumerable<H_Source_Details> detail = _db.H_Source_Details.Include().OrderBy(d=>d.Source_H_Id).ToList();
			var data = detail.Select(d => d.ToDto());
		}
	}
}