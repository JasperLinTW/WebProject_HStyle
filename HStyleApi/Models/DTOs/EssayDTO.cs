using HStyleApi.Models.EFModels;

namespace HStyleApi.Models.DTOs
{
	public class EssayDTO
	{
		public int EssayId { get; set; }
		public int InfluencerId { get; set; }
		public DateTime UplodTime { get; set; }
		public string Etitle { get; set; }
		public string Econtent { get; set; }
		public DateTime UpLoad { get; set; }
		public DateTime Removed { get; set; }
		public int CategoryId { get; set; }
		public IEnumerable<string> Imgs { get; set; }
		public IEnumerable<string> Tags { get; set; }

		//public virtual VideoCategory Category { get; set; }
		//public virtual Employee Influencer { get; set; }
		//public virtual ICollection<EassyFollow> EassyFollows { get; set; }
		//public virtual ICollection<EssaysComment> EssaysComments { get; set; }

		//public virtual ICollection<Image> Imgs { get; set; }
		//public virtual ICollection<Member> Members { get; set; }
		//public virtual ICollection<Tag> Tags { get; set; }


	}
	public static class EssayExts
		{
			public static EssayDTO ToEssayDTO(this Essay source)
			{
				return new EssayDTO()
				{
					EssayId= source.EssayId,
					InfluencerId= source.InfluencerId,
					UpLoad= source.UpLoad,
					Etitle= source.Etitle,
					Econtent= source.Econtent,
					UplodTime= source.UplodTime,
					Removed= source.Removed,
					CategoryId= source.CategoryId,
					Imgs= source.Imgs.Select(x=>x.Path),
					Tags=source.Tags.Select(x=>x.TagName),
				};
			}
		}
}
