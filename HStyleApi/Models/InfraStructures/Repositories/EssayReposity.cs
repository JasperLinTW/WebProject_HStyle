using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HStyleApi.Models.InfraStructures.Repositories
{
	public class EssayReposity
	{
		public AppDbContext _db;

		public EssayReposity(AppDbContext db)
		{
			_db = db;
		}

		public async Task<IEnumerable<EssayDTO>> GetEssays()
		{
			var data = await _db.Essays.Select(v=>v.ToEssayDTO()).ToListAsync();
			return data;
		}
		public async Task<IEnumerable<EssayDTO>> GetEssay(int id)
		{
			IEnumerable<EssayDTO> data = await _db.Essays.Where(x => x.EssayId ==id).Select(v => v.ToEssayDTO()).ToListAsync();
			if(data == null)
			{
				throw new Exception();
			}
			return data;
		}
		//public void PostLike(EssayDTO value)
		//{
		//	Essaylike
		//}
	}
}
