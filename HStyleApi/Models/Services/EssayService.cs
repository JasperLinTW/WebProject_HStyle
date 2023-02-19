using HStyleApi.Controllers;
using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace HStyleApi.Models.Services
{
	public class EssayService
	{
		private EssayReposity _essayReposity;

		public EssayService(AppDbContext db)
		{
		_essayReposity= new EssayReposity(db);
		}
		public async Task <IEnumerable<EssayDTO>> GetEssays()
		{
			var data=_essayReposity.GetEssays();
			return await data;
		}
		public async Task<IEnumerable<EssayDTO>>GetEssays(int id)
		{
			var data = _essayReposity.GetEssay(id);
			return await data;	
		}

	}
}
