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
			int freight = 100;
			OrderDTO data = new OrderDTO
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
			data.Freight = data.Total > 10000 ? 0 : freight;//todo換成變數

			return data;
		}

		public void AddItem(int memberId, int specId, int qty = 1)
        {
            bool isExit = _repo.IsExit(memberId, specId);
            if (!isExit)
            {
                _repo.AddItem(memberId,specId);
            }
            else
            {
				_repo.UpdateItem(memberId, specId, qty = 1);
			}
            
            //cart.AddItem(cartProd, qty);

            
        }
		public void MinusItem(int memberId, int specId, int qty = -1)
		{
			bool isOne = _repo.IsOne(memberId, specId);
			if (isOne)
			{
				_repo.DeleteItem(memberId, specId);
			}
			else
			{
				_repo.UpdateItem(memberId, specId, -1);
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
