using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.Services
{
	public class EssayService
	{
		private readonly IEssayRepository _repository;

		public EssayService(IEssayRepository repository)
		{
			_repository = repository;
		}

		public (bool IsSuccess, string ErrorMessage) CreateNewMember(EssayDTO dto)
		{
			// todo 判斷各欄位是否正確

			// 判斷帳號是否已存在
			if (_repository.IsExist(dto.ETitle))
			{
				return (false, "帳號已存在");                                                                                        
			}

			#region 建立一個會員記錄

			//	 建立 ConfirmCode
			dto.ConfirmCode = Guid.NewGuid().ToString("N");

			_repository.Create(dto);

			#endregion

			return (true, null);
		}
		public IEnumerable<EssayDTO> GetEssays()
		{
			return _repository.GetEssays();
		}
	}
}