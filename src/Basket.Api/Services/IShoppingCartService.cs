using Basket.Api.Entities;

namespace Basket.Api.Services
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> GetShoppingCartAsync(string userName);
        Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCart shoppingCart);
        Task DeleteShoppingCartAsync(string userName);
    }
}