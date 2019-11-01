namespace Core.Entities.OrderEntity
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}