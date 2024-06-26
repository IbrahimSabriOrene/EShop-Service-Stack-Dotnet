using System.Text.Json.Serialization;

namespace Basket.Api.Entities
{
    public class ShoppingCart
    {
        //change this part. Encapsulate the shopping cart. propg. Also Create function to create this.

        public string UserName { get; set; }
        public List<ShoppingCartItems> Items { get; set; } = new List<ShoppingCartItems>();

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            }
            private set { }
        }

    }
}