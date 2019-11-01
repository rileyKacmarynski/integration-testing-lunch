using System.Collections.Generic;

namespace Core.Entities.Cart
{
    public class Cart
    {
        public int CustomerId { get; set; }
        public IEnumerable<CartItems> Items { get; set; }
    }
}