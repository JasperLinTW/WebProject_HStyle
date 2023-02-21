namespace HStyleApi.Models.DTOs
{
	public class OrderDetailsDTO
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int UnitPrice { get; set; }
		public int Quantity { get; set; }
		public string Color { get; set; }
		public string Size { get; set; }

		public int SubTotal { get; set; }
	}

}
