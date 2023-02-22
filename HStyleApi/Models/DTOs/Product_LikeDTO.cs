namespace HStyleApi.Models.DTOs
{
	public class Product_LikeDTO
	{
		public int ProductId { get; set; }
		public int MemberId { get; set; }
		public string ProductName { get; set; }
		public int UnitPrice { get; set; }
	}
}
