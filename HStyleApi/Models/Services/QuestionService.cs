using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;

namespace HStyleApi.Models.Services
{
	public class QuestionService
	{
		private QuestionRepository _questionRepository;

		public QuestionService(AppDbContext db)
		{
			_questionRepository = new QuestionRepository(db);
		}

		public async Task<IEnumerable<CommonQuestionDTO>> GetCommonQuestion()
		{
			var data = _questionRepository.GetCommonQuestion();
			return await data;
		}

		public void PostCustomerQuestion(CustomerQuestionDTO dto)
		{
			if (dto == null)
			{
				throw new Exception();
			}
			else
			{
				_questionRepository.PostCustomerQuestion(dto);
			}
		}
	}
}
