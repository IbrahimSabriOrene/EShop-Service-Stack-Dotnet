using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.Api.Entities;
using EShop.Web.Models.Catalog;
using EShop.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EShop.Web.Pages
{
    public class ProductDetails : PageModel
    {
        private readonly ILogger<ProductDetails> _logger;
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;
        public ProductDetails(ILogger<ProductDetails> logger, ICatalogService catalogService, IBasketService basketService)
        {
            _logger = logger;
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }
        public CatalogItemModel Product { get; set; } = new CatalogItemModel();
        public ShoppingCartModel CartModel { get; set; } = new ShoppingCartModel();


        public async Task<IActionResult> OnGetAsync(int productId)
        {
            Product = await _catalogService.GetCatalog(productId);
            return Page();

        }
        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            _logger.LogInformation("productId" + productId);
            var product = await _catalogService.GetCatalog(productId);
            var userName = User.Identity!.Name!;
            var basket = await _basketService.GetBasket(userName);
            var quantity = 1;
           
            //Algorithm -> If the product is already in the basket, 

            // Or just tell item already
            // increase the quantity by 1. If the product is not in the basket, add the product to the basket.

             // var item = basket.Items.FirstOrDefault(x => x.ProductId == productId);
             // if (item != null)
             // {
             //     item.Quantity += quantity;
             // }
            if (basket.UserName == null)
            {
                basket = new ShoppingCartModel
                {
                    UserName = userName
                };

            }
            basket.Items.Add(new ShoppingCartItemsModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = quantity,
                Price = product.Price,
                ImageFile = product.ImageFile

            });

            await _basketService.UpdateBasket(basket);
            return RedirectToPage(pageName: "ProductDetails", routeValues: new { productId = productId });
        }
        // Get Product Details by Product Id
    }
}