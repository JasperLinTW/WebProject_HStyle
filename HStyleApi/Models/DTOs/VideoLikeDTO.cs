using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;

namespace HStyleApi.Models.DTOs
{
	public class VideoLikeDTO
	{
		public int VideoId { get; set; }
		public int MemberId { get; set; }

		public virtual Video Video { get; set; }

		public bool IsOnShelff  { get; set; }
	}
	public static class VideoLikeExts
	{
		public static VideoLike ToVideoLike(this VideoLikeDTO source)
		{
			return new VideoLike()
			{
				VideoId = source.VideoId,
				MemberId = source.MemberId
			};
		}
		public static VideoLikeDTO ToLikeDTO(this VideoLike source)
		{
			return new VideoLikeDTO()
			{
				VideoId = source.VideoId,
				MemberId = source.MemberId,
			};
		}
	}
}
