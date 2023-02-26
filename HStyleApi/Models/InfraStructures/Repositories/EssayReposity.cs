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

		//文章列表
		public async Task<IEnumerable<EssayDTO>> GetEssays(string keyword)
		{
			IEnumerable<Essay> data = await _db.Essays.Include(e => e.Imgs)
				.Include(e => e.Tags)
				.Include(e => e.Elikes)
				.Include(e => e.Category)
				.ToListAsync();
			if(data == null)
			{
				throw new Exception();
			}
			if(keyword== null)
			{
				IEnumerable<EssayDTO>essays=data.Select(e => e.ToEssayDTO());
				return essays;
			}
			else
			{
				IEnumerable<EssayDTO> selectEssays = data.Where(x => x.Etitle.Contains(keyword) || x.Tags.Select(t => t.TagName).Contains(keyword)).Select(x => x.ToEssayDTO());
			    return selectEssays;
			}
		}
		//當一文章
		public async Task<IEnumerable<EssayDTO>> GetEssay(int id)
		{
			IEnumerable<EssayDTO> essays = await _db.Essays.Where(e => e.EssayId == id)
				.Include(e => e.Imgs)
				.Include(e => e.CategoryId)
				.Include(e => e.Tags)
				.Include(e => e.Elikes)
				.Select(x => x.ToEssayDTO())
				.ToListAsync();
			if (essays == null)
			{
				throw new Exception();
			}
			
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

		public async Task<IEnumerable<EssayDTO>> GetNews()
		{
			throw new NotImplementedException();
		}
	}
}
