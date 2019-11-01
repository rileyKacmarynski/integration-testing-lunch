using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Entities.CartEntity
{
    public class Cart
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();
        public ReadOnlyCollection<CartItem> Items => _cartItems.AsReadOnly();
        public int CartId { get; set; }
        public Customer Customer { get; set; }
    }
}