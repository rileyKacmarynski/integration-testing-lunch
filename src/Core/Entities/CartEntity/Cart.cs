using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Entities.CartEntity
{
    public class Cart
    {
        private readonly ICollection<CartItem> _cartItems = new List<CartItem>();
        public ICollection<CartItem> Items => _cartItems;
        public int CartId { get; set; }
        public Customer Customer { get; set; }

        internal void CreateCartItem(Product item)
        {
            _cartItems.Add(new CartItem 
            {
                Price = item.Price,
                Product = item,
                Quantity = 1,
            });
        }
    }
}