using HStyleApi.Controllers;
using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HStyleApi.Models.Services
{
	public class EssayService
	{
		private EssayReposity _essayReposity;

		public EssayService(AppDbContext db)
		{
			_essayReposity = new EssayReposity(db);
		}
		public async Task<IEnumerable<EssayDTO>> GetEssays(string? keyword)
		{
			var data = await _essayReposity.GetEssays(keyword);
			return data;
		}
		public async Task<IEnumerable<EssayDTO>> GetEssays(int id)
		{
			var data = _essayReposity.GetEssay(id);
			return await data;
		}


		public async Task<IEnumerable<EssayLikeDTO>> GetlikeEssays(int MemberId)
		{
			var data = _essayReposity.GetlikeEssays(MemberId);
			return await data;
		}
		public void PostELike(int memberId, int essayId)
		{
			if (memberId == 0 || essayId == 0) throw new Exception();
			else _essayReposity.PostELike(memberId, essayId);

		}

        public async Task<IEnumerable<EssayDTO>> GetNews()
        {
            var data = _essayReposity.GetNews();
            return await data;
        }

        public async Task<IEnumerable<EssayCommentDTO>> GetComments(int essayId)
		{
			return await _essayReposity.GetComments(essayId);

		}

		public void CreateComment(string comment, int memberId, int essayId)
		{
			_essayReposity.CreateComment(comment, memberId, essayId);
		}

		public void PostCommentLike(int memberId, int essayId)
		{
			_essayReposity.PostCommentLike(memberId, essayId);
		}
	}
}
