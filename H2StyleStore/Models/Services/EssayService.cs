using H2StyleStore.Models.DTOs;
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
	}
}