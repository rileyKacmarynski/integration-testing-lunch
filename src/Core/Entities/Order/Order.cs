using System.Collections.Generic;

namespace Core.Entities.OrderEntity
{
    public class Order
    {
        private IEnumerable<OrderItem> _orderItems = new List<OrderItem>();
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
    }
}