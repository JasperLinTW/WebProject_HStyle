using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;

namespace HStyleApi.Models.Services
{
    public class CartService
    {
        private readonly CartRepo _repo;
        public CartService(CartRepo repo)
        {
            _repo = repo;
        }
		public CartListDTO GetCart(int memberId)
        {
            return _repo.GetCart(memberId);
        }

        public OrderDTO GetCheckout(int memberId, CheckoutDTO value)
        {
			var cartlist = GetCart(memberId);
			bool isInStock = _repo.CheckStocks(memberId);

			if(isInStock == false)
			{
				throw new Exception("您有商品庫存不足，已刪除不足品項，請重新選購");
			}

			int freight = 100;
			OrderDTO newOrder = new OrderDTO
			{
				MemberId = memberId,
				OrderDetails = cartlist
				.CartItems
				.Select(x => new OrderDetailsDTO
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					Quantity = x.Quantity,
					UnitPrice = x.UnitPrice,
					SubTotal = x.Quantity * x.UnitPrice,
					Color= x.Color,
					Size= x.Size,
				}),
				Total = cartlist.Total,
				Payment = value.Payment,
				ShipVia = value.ShipVia,
				ShipName = value.ShipName,
				ShipPhone = value.ShipPhone,
				ShipAddress = value.ShipAddress,
				CreatedTime = DateTime.Now,
				StatusId = 1,//有待付款狀態
				StatusDescriptionId = 9,

			};
			newOrder.Freight = newOrder.Total > 10000 ? 0 : freight;//todo換成變數

			return newOrder;
		}

		public void AddItem(int memberId, int specId)
        {
			var cartItem = _repo.GetCart(memberId).CartItems.Where(x => x.SpecId == specId).FirstOrDefault();
			int qty = cartItem == null ? 1 : cartItem.Quantity+1;

			if (_repo.CheckStock(specId) < qty) throw new Exception("庫存量不足，已刪除品項，請重新選購");    

            if (cartItem == null)
            {
                _repo.AddItem(memberId,specId);
            }
            else
            {
				_repo.UpdateItem(memberId, specId, qty);
			}
            
            //cart.AddItem(cartProd, qty);

            
        }
		public void MinusItem(int memberId, int specId)
		{
			var cartItem = _repo.GetCart(memberId).CartItems.Where(x => x.SpecId == specId).FirstOrDefault();

			if (cartItem == null) throw new Exception("商品已不存在");

			int qty = cartItem.Quantity - 1;
			if (qty == 0)
			{
				_repo.DeleteItem(memberId, specId);
			}
			else
			{
				_repo.UpdateItem(memberId, specId, qty);
			}

			//cart.AddItem(cartProd, qty);


		}

		public int CreateOrder(OrderDTO checkoutList)
		{
			//todo，取有多少幣、判斷是否大於20%、扣除本次使用量
			int orderId = _repo.CreateOrder(checkoutList);
			
			return orderId;
		}
	}
    
}
