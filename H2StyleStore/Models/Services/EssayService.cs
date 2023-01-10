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


		public IEnumerable<EssayDTO> GetEssays()
		{
			return _repository.GetEssays();
		}


		//public (bool IsSuccess, string ErrorMessage) CreateVideo(CreateEssayDTO dto)
		//{
		//	if (_repository.IsExist(dto.Image, dto.FilePath))
		//	{
		//		return (false, "這部影片已經上傳過了");
		//	}

		//	_repository.Create(dto);
		//	return (true, null);
		//}


		public (bool, string) Create(EssayDTO dto)
		{
			if (_repository.IsExist(dto.ETitle))
			{
				return (false, "標題名稱已使用，請更改名稱");
			}

			_repository.Create(dto);

			return (true, null);

		}

		public (bool, string) Create(CreateEssayDTO dto)
		{
			if (_repository.IsExist(dto.ETitle))
			{
				return (false, "標題名稱已使用，請更改名稱");
			}



			_repository.Create(dto);

			return (true, null);

		}
	}
}