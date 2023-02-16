using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;

namespace HStyleApi.Models.InfraStructures.Repositories
{
    public class CartRepo
    {
        private readonly HstyleStoreContext _db;
        public CartRepo(HstyleStoreContext db)
        {
            _db= db;
        }
        
        public void AddItem(int memberId, int specId, int qty = 1)
		{
            var newItem = new Cart()
            {
                MemberId = memberId,
                SpecId = specId,
                Quantity = qty
            };
            _db.Add(newItem);
            _db.SaveChanges();
        }

        public IEnumerable<CartDTO> GetCart(int memberId)
        {
            var cartItems =_db.Carts.Where(x => x.MemberId==memberId).Select(x => new CartDTO()
            {
                MemberId = x.MemberId,
                SpecId= x.SpecId,
                Quantity= x.Quantity,
            });
            return cartItems; 
        }

        public bool IsExit(int memberId, int specId)
        {
			var cartItems = _db.Carts.Where(x => x.MemberId == memberId && x.SpecId == specId);
            return cartItems.Any();
		}
        public void UpdateItem(int memberId, int specId, int qty = 1)
        {
            var cart = _db.Carts.Where(x => x.MemberId == memberId && x.SpecId == specId).SingleOrDefault();
            cart.Quantity += 1; 

            _db.SaveChanges();
        }

	}
}
