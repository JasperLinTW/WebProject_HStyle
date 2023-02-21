using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.EntityFrameworkCore;

namespace HStyleApi.Models.InfraStructures.Repositories
{
	public class QuestionRepository
	{
		private AppDbContext _db;

		public QuestionRepository(AppDbContext db)
		{
			_db = db;
		}

		public async Task<IEnumerable<CommonQuestionDTO>> GetCommonQuestion()
		{
			var data = await _db.CommonQuestions.Select(q => q.ToCommonQuestionDTO()).ToListAsync();

			return data;
		}

		public void PostCustomerQuestion(CustomerQuestionDTO dto)
		{
			CustomerQuestion question = dto.ToCustomerQ();
			_db.CustomerQuestions.Add(question);
			_db.SaveChanges();
		}
	}
}
