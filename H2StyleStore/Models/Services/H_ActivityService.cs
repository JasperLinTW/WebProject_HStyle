using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Services
{

	public class H_ActivityService
	{
		private readonly IH_ActivityRepository _repository;
		public H_ActivityService(IH_ActivityRepository repo)
		{
			_repository = repo;
		}

		public IEnumerable<H_ActivityDto> GetHActivity()
		{
			return _repository.GetHActivity();
		}
		public IEnumerable<H_ActivityDto> GetHActivityItem(int id)
		{
			
			return _repository.GetHActivityItem(id);
		}
	}
}