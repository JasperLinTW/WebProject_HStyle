using HStyleApi.Models.EFModels;

namespace HStyleApi.Models.DTOs
{
	public class PCommentPostDTO
	{
		public string CommentContent { get; set; }
		public int Score { get; set; }
		public List<string> PcommentImgs { get; set; }
	}
}
