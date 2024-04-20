namespace Basket.Api.Entities
{
    public class ShoppingCartItemsModel
    {
        public int Quantity { get; set; }
        public string? ImageFile { get; set; }
        public decimal Price { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
    }
}