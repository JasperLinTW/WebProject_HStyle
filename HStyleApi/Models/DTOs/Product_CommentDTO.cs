namespace HStyleApi.Models.DTOs
{
	public class Product_CommentDTO
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string PostContent { get; set; }
		public System.DateTime CreateDateTime { get; set; }
		public Nullable<System.DateTime> LastModifyDateTime { get; set; }
		public string CoverImg { get; set; }
	}
}
