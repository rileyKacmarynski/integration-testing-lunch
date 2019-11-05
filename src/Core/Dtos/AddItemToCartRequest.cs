using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos
{
    public class AddItemToCartRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
    }
}
