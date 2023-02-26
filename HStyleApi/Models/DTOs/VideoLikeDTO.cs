using HStyleApi.Models.EFModels;

namespace HStyleApi.Models.DTOs
{
	public class VideoLikeDTO
	{
		public int Id { get; set; }
		public int VideoId { get; set; }
		public int MemberId { get; set; }
		public DateTime CreatedTime { get; set; }

		public virtual Video Video { get; set; }
	}
	public static class VideoLikeExts
	{
		public static VideoLike ToVideoLike(this VideoLikeDTO source)
		{
			return new VideoLike()
			{
				//Id = source.Id,
				VideoId = source.VideoId,
				MemberId = source.MemberId,
				//CreatedTime = source.CreatedTime
			};
		}
	}
}
