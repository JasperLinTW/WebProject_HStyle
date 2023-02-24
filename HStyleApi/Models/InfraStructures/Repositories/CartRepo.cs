using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.EntityFrameworkCore;

namespace HStyleApi.Models.InfraStructures.Repositories
{
    public class CartRepo
    {
        private readonly AppDbContext _db;
        private string _basePath;
        public CartRepo(AppDbContext db)
        {
            _db= db;
		    _basePath = "https://localhost:44313/Images";
		}
        
        public void AddItem(int memberId, int specId)
		{
            var newItem = new Cart()
            {
                MemberId = memberId,
                SpecId = specId,
                Quantity = 1
            };
            _db.Add(newItem);
            _db.SaveChanges();
        }

        public CartListDTO GetCart(int memberId)
        {
            var cartItems =_db.Carts
                .Include(c => c.Spec)
                .ThenInclude(s => s.Product)
                .ThenInclude(p => p.Imgs)
                .Select(x => new CartDTO()
            {
                MemberId = x.MemberId,
                ProductId=x.Spec.ProductId,
                ProductName = x.Spec.Product.ProductName,
                Image =$"{_basePath}/ProductImages/{x.Spec.Product.Imgs.FirstOrDefault().Path}",
                SpecId= x.SpecId,
                Size= x.Spec.Size,
                Color= x.Spec.Color,
                Quantity= x.Quantity,
				UnitPrice = x.Spec.Product.UnitPrice,

            });

            var cartList = new CartListDTO()
            {
                CartItems = cartItems,

            };
            return cartList; 
        }

        public bool IsExit(int memberId, int specId)
        {
			var cartItems = _db.Carts.Where(x => x.MemberId == memberId && x.SpecId == specId);
            return cartItems.Any();
		}
		public bool IsOne(int memberId, int specId)
		{
			var cartItems = _db.Carts.Where(x => x.MemberId == memberId && x.SpecId == specId).SingleOrDefault();
			return cartItems.Quantity==1;
		}
		public void UpdateItem(int memberId, int specId, int qty)
        {
            var cart = _db.Carts.Where(x => x.MemberId == memberId && x.SpecId == specId).SingleOrDefault();
            cart.Quantity += qty; 

            _db.SaveChanges();
        }
		public void DeleteItem(int memberId, int specId)
		{
			var cart = _db.Carts.Where(x => x.MemberId == memberId && x.SpecId == specId).SingleOrDefault();
			_db.Carts.Remove(cart);

			_db.SaveChanges();
		}

		public int CreateOrder(OrderDTO value)
		{
            if (value.Total <= 0)
            {
                throw new Exception("購物車內沒有商品");
            }
			var order = new Order()
            {
				MemberId = value.MemberId,
				OrderDetails = value.OrderDetails
				.Select(x => new OrderDetail
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					Quantity = x.Quantity,
					UnitPrice = x.UnitPrice,
					SubTotal = x.Quantity * x.UnitPrice,
					Color = x.Color,
					Size = x.Size,
				}).ToList(),
				Total = value.Total,
				Payment = value.Payment,
				ShipVia = value.ShipVia,
				ShipName = value.ShipName,
				ShipPhone = value.ShipPhone,
				ShipAddress = value.ShipAddress,
				CreatedTime = DateTime.Now,
				StatusId = value.StatusId,//有待付款狀態
				StatusDescriptionId = value.StatusDescriptionId,
			};
            _db.Orders.Add(order);
            var dataLog = new OrderLog
            {
                OrderId = value.OrderId,
                StatusChangedTime = DateTime.Now,
                Status = "待處理",
            };
            _db.OrderLogs.Add(dataLog);
            var cartItems = _db.Carts.Where(x => x.MemberId == order.MemberId);
            _db.RemoveRange(cartItems);

            _db.SaveChanges();
            return order.OrderId;
		}
	}
}
