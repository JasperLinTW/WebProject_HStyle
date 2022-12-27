using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
	public class EssayRepository : IEssayRepository
	{
		private readonly AppDbContext _db;
		public EssayRepository(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<EssayDTO> GetEssays()
		{
			IEnumerable<Essay> query = _db.Essays;
			//.Include("PCategory");

			query = query.OrderBy(x => x.Essay_Id);

			return query.Select(x => x.ToDto());
		}
	}
}