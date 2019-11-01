using System.Collections.Generic;

namespace Core.Entities.Order
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}