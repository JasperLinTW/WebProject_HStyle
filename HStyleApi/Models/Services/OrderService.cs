using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;

namespace HStyleApi.Models.Services
{
	public class OrderService
	{
		private readonly OrderRepo _repo;
		public OrderService(OrderRepo repo)
		{
			_repo = repo;
		}

		public IEnumerable<OrderDTO> GetOrders(int memberId)
		{
			var orders = _repo.GetOrders(memberId);
			return orders;
		}
	}
}
