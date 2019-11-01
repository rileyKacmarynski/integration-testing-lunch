using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Entities.OrderEntity
{
    public class Order
    {
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public ReadOnlyCollection<OrderItem> Items => _orderItems.AsReadOnly();
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
    }
}