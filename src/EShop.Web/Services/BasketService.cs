using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Basket.Api.Entities;
using EShop.Web.Pages;

namespace EShop.Web.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;
        private readonly ILogger<BasketService> _logger;
        public BasketService(HttpClient client, ILogger<BasketService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger;
        }

        public async Task<ShoppingCartModel> GetBasket(string userName)
        {
            
            var response = await _client.GetAsync($"/ShoppingCartApi/GetShoppingCartId/{userName}");
            var content = await response.Content.ReadFromJsonAsync<ShoppingCartModel>() ?? throw new Exception("Something went wrong when calling api.");
            return content;
        }

        public async Task<ShoppingCartModel> UpdateBasket(ShoppingCartModel? model)
        {
            

            
            var serialized = JsonSerializer.Serialize(model);
            
            var request = new StringContent(
                serialized,
                Encoding.UTF8,
                "application/json");

            var response = await _client.PostAsync("/ShoppingCartApi/UpdateShoppingCartAsync", request);

            if (response != null && response.IsSuccessStatusCode)
            {
                
                var content = await response.Content.ReadFromJsonAsync<ShoppingCartModel>();
                return content ?? throw new Exception("The response content is empty after updating the catalog.");}
            else
            {
                var errorMessage = response != null 
                    ? $"Error calling API. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}"
                    : "Error calling API. The response is null.";

                throw new Exception(errorMessage);
            }
        }


        //public async Task CheckoutBasket(BasketCheckoutModel model)
        //{
        //    var response = await _client.PostAsJson($"/Basket/Checkout", model);
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new Exception("Something went wrong when calling api.");
        //    }
        //}
    }
}