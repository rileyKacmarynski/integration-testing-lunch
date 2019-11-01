namespace Core.Entities.Order
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }  // we can get rid of this in favor of doing ef things
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}