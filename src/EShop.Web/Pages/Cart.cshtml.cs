using Basket.Api.Entities;
using EShop.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Pages
{
    public class Cart : PageModel
    {
        private readonly ILogger<Cart> _logger;
        private readonly IBasketService _basketService;
        public ShoppingCartModel CartModel { get; set; } = new ShoppingCartModel();

        public Cart(ILogger<Cart> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = User.Identity!.Name!;

            CartModel = await _basketService.GetBasket(userName);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(int productId)
        {
            var userName = User.Identity!.Name!;
            var basket = await _basketService.GetBasket(userName);
            var item = basket.Items.Single(x => x.ProductId == productId);
            if(item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                basket.Items.Remove(item);
            }
            await _basketService.UpdateBasket(basket);
            return RedirectToPage();
        }


    }
}