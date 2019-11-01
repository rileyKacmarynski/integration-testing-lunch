namespace Core.Entities.CartEntity
{
    public class CartItem
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}