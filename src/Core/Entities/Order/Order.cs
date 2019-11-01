using System.Collections.Generic;

namespace Core.Entities.OrderEntity
{
    public class Order
    {
        private IEnumerable<OrderItem> _orderItems = new List<OrderItem>();
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
    }
}