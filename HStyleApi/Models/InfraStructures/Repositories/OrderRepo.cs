using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.EntityFrameworkCore;

namespace HStyleApi.Models.InfraStructures.Repositories
{
	public class OrderRepo
	{
		private readonly AppDbContext _db;
		public OrderRepo(AppDbContext db )
		{
			_db = db;
		}

		public IEnumerable<OrderDTO> GetOrders(int memberId)
		{
			var data = _db.Orders.Include(o => o.OrderDetails).Where(o => o.MemberId== memberId).Select(x => x.ToDTO());
			return data;
			
		}
	}
}
