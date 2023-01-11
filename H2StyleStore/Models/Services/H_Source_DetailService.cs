using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Services
{
	public class H_Source_DetailService
	{
		private readonly IH_Source_DetailRepository _repository;
		public H_Source_DetailService(IH_Source_DetailRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<H_Source_DetailDto> GetSource()
			=> _repository.GetSource();

		public IEnumerable<H_CheckInDto> GetCheckIn()
			=> _repository.GetCheckIn();

		public string CreateHDetail(H_Source_DetailDto dto)
		{
			try
			{
				_repository.CreateHDetail(dto);
				return "新增成功";
			}
			catch (Exception ex) { return ex.Message; }
		}
	}
}