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

		public H_ActivityDto GetHActivityById(int id)
		{
			var data = _db.H_Activities.Find(id).ToDto();
			return data;
		}
		public void Update(H_ActivityDto dto)
		{
			H_Activities activity = _db.H_Activities.Find(dto.H_Activity_Id);

			activity.Activity_Name = dto.Activity_Name;
			activity.Activity_Describe = dto.Activity_Describe;
			activity.H_Activity_Id = dto.H_Activity_Id;

			_db.SaveChanges();
		}


		public void Create(H_ActivityDto dto)
		{
			H_Activities activity = new H_Activities
			{
				Activity_Name = dto.Activity_Name,
				Activity_Describe = dto.Activity_Describe,
				H_Value = dto.H_Value,
			};
			_db.H_Activities.Add(activity);
			_db.SaveChanges();
		}

	}
}