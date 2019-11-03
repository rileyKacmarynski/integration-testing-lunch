using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Entities.CartEntity;

namespace Core.Entities.OrderEntity
{
    public class Order
    {
        protected Order(){ } // EF Needs this one
        public Order(Customer customer)
        {
            Customer = customer;
        }

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public ReadOnlyCollection<OrderItem> Items => _orderItems.AsReadOnly();
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }

        internal void AddItems(ICollection<CartItem> items)
        {
            foreach(var item in items)
            {
                _orderItems.Add(new OrderItem
                {
                    Product = item.Product,     // this doesn't work, but we
                    Quantity = item.Quantity,
                    Total = item.Price * item.Quantity
                });
            }
        }
    }
}