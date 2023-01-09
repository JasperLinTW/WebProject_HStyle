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

		public string CreateNewActivity(H_ActivityDto dto)
		{			
			try
			{
				_repository.Create(dto);

				return "新增成功";
			}
			catch (Exception ex) { return ex.Message; }
		}

		public void UpdateActivity(H_ActivityDto dto) 
		{
			H_ActivityDto entity  = _repository.GetHActivityById(dto.H_Activity_Id);
			if (entity == null) throw new Exception("找不到要修改的紀錄");

			entity.Activity_Name=dto.Activity_Name;
			entity.Activity_Describe=dto.Activity_Describe;
			entity.H_Value=dto.H_Value;

			_repository.Update(entity);
		}
	
	}
}