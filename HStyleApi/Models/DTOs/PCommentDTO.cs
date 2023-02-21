using HStyleApi.Models.EFModels;
using System.Runtime.CompilerServices;

namespace HStyleApi.Models.DTOs
{
	public class PCommentDTO
	{
		public int CommentId { get; set; }
		public string Color { get; set; }
		public string Size { get; set; }
		public string CommentContent { get; set; }
		public int Score { get; set; }
		public virtual ICollection<Image> PcommentImgs { get; set; }
	}

	public static class ProductCommentExts
	{
		public static PCommentDTO ToDto(this ProductComment source)
		{
			return new PCommentDTO
			{
			   CommentId = source.CommentId,
			   CommentContent = source.CommentContent,
			   PcommentImgs = source.PcommentImgs,
			   Score = source.Score,
			};

		}
	}
}
