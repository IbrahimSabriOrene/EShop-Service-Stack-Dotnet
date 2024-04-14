
using Basket.Api.Entities;
using EShop.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Pages
{
    public class Basket : PageModel
    {
        private readonly ILogger<Basket> _logger;
        private readonly IBasketService _basketService;
        public string UserName { get; set; } = null!;

        public Basket(ILogger<Basket> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        public ShoppingCartModel Cart { get; set; } = new ShoppingCartModel();

        

    }
}