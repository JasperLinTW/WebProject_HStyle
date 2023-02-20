namespace HStyleApi.Models.DTOs
{
	public class CheckoutDTO
	{
		public int MemberId { get; set; }
		public IEnumerable<CheckoutItemsDTO> CartItems { get; set; }
		public int Total { get; set; }
		public string Payment { get; set; }
		public string ShipVia { get; set; }
		public int Freight { get; set; }
		public string ShipName { get; set; }
		public string ShipAddress { get; set; }
		public string ShipPhone { get; set; }
		public DateTime CreatedTime { get; set; }
		public int StatusId { get; set; }
		public int? StatusDescriptionId { get; set; }

	}
}
