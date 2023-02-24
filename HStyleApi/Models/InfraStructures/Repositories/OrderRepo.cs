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
		public OrderDTO GetOrder(int orderId)
		{
			var data = _db.Orders.Include(o => o.OrderDetails).Where(o => o.OrderId == orderId).Select(x => x.ToDTO()).SingleOrDefault();


			return data;

		}

		public void SavePayInfo(int orderId,string paypalInfo)
		{
			var order = _db.Orders.Where(x =>x.OrderId == orderId).SingleOrDefault();
            order.PayInfo = paypalInfo;

			_db.SaveChanges();

		}

        public void UpdateOrder(string palpaltoken)
        {
            var order = _db.Orders.Where(o => o.PayInfo== palpaltoken).SingleOrDefault();
			order.StatusId = 2;
			order.StatusDescriptionId = 10;
			_db.SaveChanges();
        }
    }
}
