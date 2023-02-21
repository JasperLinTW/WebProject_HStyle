using HStyleApi.Models.EFModels;

namespace HStyleApi.Models.DTOs
{
	public class CommonQuestionDTO
	{
		public int CommonQuestionId { get; set; }
		public int QcategoryId { get; set; }
		public string? Question { get; set; }
		public string? Answer { get; set; }
		public int SatiafactionClick { get; set; }
		public int SatiafactionYes { get; set; }
	}

	public static class CommonQuestionDTOExts
	{
		public static CommonQuestionDTO ToCommonQuestionDTO(this CommonQuestion source)
		{
			return new CommonQuestionDTO
			{
				CommonQuestionId = source.CommonQuestionId,
				QcategoryId = source.QcategoryId,
				Question = source.Question,
				Answer = source.Answer,
				SatiafactionClick = source.SatiafactionClick,
				SatiafactionYes = source.SatiafactionYes,
			};
		}
	}
}
