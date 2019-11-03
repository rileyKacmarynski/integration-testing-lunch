using System;
using System.Linq;
using Core.Entities.CartEntity;

namespace Core.Entities
{
    public class Customer
    {
        public Customer(){ }
        public Customer(string username)
        {
            Username = username;
            Cart = new Cart();
        }

        public int CustomerId { get; set; }
        public string Username { get; set; }
        public Cart Cart { get; set; }

        internal void EmptyCart()
        {
            Cart = new Cart();
        }

        public void AddItemToCart(Product orderProduct)
        {
            var item = Cart.Items.SingleOrDefault(i => i.Product?.ProductId == orderProduct.ProductId);
            if(item == null)
            {
                Cart.CreateCartItem(orderProduct);
            }
            else
            {
                item.Quantity++;
            }
        }
    }
}