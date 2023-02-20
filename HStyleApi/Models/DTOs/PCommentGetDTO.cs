using HStyleApi.Models.EFModels;

namespace HStyleApi.Models.DTOs
{
	public class PCommentGetDTO
	{
		public int CommentId { get; set; }
		public OrderDetail OrderDetail { get; set; }
	}
}
