namespace Core.Entities.Cart
{
    public class CartItems
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}