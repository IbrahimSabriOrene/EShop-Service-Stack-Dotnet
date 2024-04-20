using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<CatalogTypeModel> CategoryList { get; set; } = new List<CatalogTypeModel>();
        public CatalogItemModel Product { get; set; } = new CatalogItemModel();
        public ProductDetails(ILogger<ProductDetails> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        public async Task OnGetAsync(int productId)
        {
            var product = await _catalogService.GetCatalog(productId);

        }

        // Get Product Details by Product Id
    }
}