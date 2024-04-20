using Basket.Api.Entities;
using EShop.Web.Models.Catalog;
using EShop.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ICatalogService _catalogService;
    private readonly IBasketService _basketService;



    public IndexModel(ILogger<IndexModel> logger, ICatalogService catalogService, IBasketService basketService)
    {
        _logger = logger;
        _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
        _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
    }
    public IEnumerable<CatalogItemModel> ProductList { get; set; } = new List<CatalogItemModel>();
    public IEnumerable<CatalogTypeModel> CategoryList { get; set; } = new List<CatalogTypeModel>();
    public async Task<IActionResult> OnPostAddToCartAsync(int productId)
    {
        _logger.LogInformation("productId" + productId);
        var product = await _catalogService.GetCatalog(productId);
        var userName = User.Identity!.Name!;
        var basket = await _basketService.GetBasket(userName);
        var quality = 1;
       
            var item = basket.Items.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                item.Quantity += quality;
            }
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
            Quantity = quality, // Quantity is chosen by the user. Get it from the form.
            Price = product.Price,
            ImageFile = product.ImageFile

        });
        await _basketService.UpdateBasket(basket);
        return RedirectToPage();
    }
    public async Task<IActionResult> OnGetAsync()
    {
        ProductList = await _catalogService.GetCatalog();
        CategoryList = await _catalogService.GetCategories();
        return Page();
    }
}

