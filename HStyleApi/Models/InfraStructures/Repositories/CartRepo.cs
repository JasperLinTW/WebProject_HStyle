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
        
        public void AddItem()
        {
            var cart = _db.Carts.Add();
        }

        public List<Cart> GetCart(int memberId)
        {
            _db.Carts.
        }
    }
}
