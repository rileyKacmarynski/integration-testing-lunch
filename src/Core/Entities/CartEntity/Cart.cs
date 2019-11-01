using System.Collections.Generic;

namespace Core.Entities.CartEntity
{
    public class Cart
    {
        private List<CartItem> _cartItems = new List<CartItem>();
        public int CartId { get; set; }
        public Customer Customer { get; set; }
    }
}