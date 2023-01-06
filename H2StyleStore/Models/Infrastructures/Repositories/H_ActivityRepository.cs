using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
	public class H_ActivityRepository : IH_ActivityRepository
	{
		private AppDbContext _db;
		public H_ActivityRepository(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<H_ActivityDto> GetHActivity()
		{
			IEnumerable<H_Activities> activity = _db.H_Activities.OrderBy(x => x.H_Activity_Id).ToList();
			var data = activity.Select(a => a.ToDto());

			return data;
		}
		public IEnumerable<H_ActivityDto> GetHActivityItem(int id)
		{
			IEnumerable<H_Activities> activity = _db.H_Activities
				.Where(a => a.H_Activity_Id == id)
				.ToList();
			var data = activity.Select(a => a.ToDto());

			return data;
		}
	}
}