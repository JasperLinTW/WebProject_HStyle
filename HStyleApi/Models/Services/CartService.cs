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
	}
    
}
