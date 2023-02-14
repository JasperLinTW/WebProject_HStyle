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
    }
    public CartEntity Current(string customerAccount)
    {
        if (_repository.IsExists(customerAccount))
        {
            return _repository.Load(customerAccount);
        }
        else
        {
            return _repository.CreateNewCart(customerAccount);
        }
    }
    public void AddItem(int memberId, int productId, int qty = 1)
    {
        var cart = Current(customerAccount);

        var product = _productRepo.Load(productId, true);
        var cartProd = new CartProductEntity { Id = productId, Name = product.Name, Price = product.Price };

        cart.AddItem(cartProd, qty);

        _repository.Save(cart);
    }
}
