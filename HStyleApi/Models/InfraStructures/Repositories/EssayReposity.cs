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

		public async Task<IEnumerable<EssayDTO>> GetEssays(string keyword)
		{
			IEnumerable<Essay> data = await _db.Essays.Include(e => e.Imgs)
				.Include(e => e.Tags)
				.Include(e => e.Elikes)
				.ToListAsync();
			if(data == null)
			{
				throw new Exception();
			}
			if(keyword== null)
			{
				return data.Select(x => x.ToEssayDTO());
			}
			else
			{
				IEnumerable<EssayDTO> selectEssays = data.Where(x => x.Etitle.Contains(keyword) || x.Tags.Select(t => t.TagName).Contains(keyword)).Select(x => x.ToEssayDTO());
			    return selectEssays;
			}
		}
		public async Task<IEnumerable<EssayDTO>> GetEssay(int id)
		{
			IEnumerable<Essay> data = await _db.Essays.Where(x => x.EssayId ==id)
				.Include(e => e.Imgs)
				.Include(e => e.Tags)
				.Include(e => e.Elikes)
				.ToListAsync();
			if (data == null)
			{
				throw new Exception();
			}
			IEnumerable<EssayDTO> essays = data.Select(x => x .ToEssayDTO());
			return essays;
		}
		public async Task<IEnumerable<EssayLikeDTO>> GetlikeEssays(int memberId)
		{
			IEnumerable<Elike> data = await _db.Elikes
				.Include(e => e.Essay)
				.ThenInclude(e => e.Imgs)//根據essay裡面撈資料 ThenInclude
				.Include(e => e.Essay)//關聯essay ==> tags
				.ThenInclude(e => e.Tags)
				
				.Where(e => e.MemberId == memberId)
				.ToListAsync();
			if (data == null)
			{
				throw new Exception();
			}
			IEnumerable<EssayLikeDTO> elike = data.Select(e => e.ToElikeDTO());
			return elike;
		}

		public void PostELike(int memberId, int essayId)
		{
			var data = _db.Elikes.Where(e=>e.MemberId== memberId).FirstOrDefault(e=>e.EssayId== essayId);
			if (data == null)
			{
				Elike like = new Elike //like 新的容器，存入到資料表Elike，在一個新的Elike
				{
					MemberId = memberId,
					EssayId = essayId,
				};
				_db.Elikes.Add(like);
			}
			else _db.Elikes.Remove(data);
			_db.SaveChanges();
		}
	}
}
