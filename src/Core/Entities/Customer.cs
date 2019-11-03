using Core.Entities.CartEntity;

namespace Core.Entities
{
    public class Customer
    {
        public Customer(){ }
        public Customer(string username)
        {
            Username = username;
        }

        public int CustomerId { get; set; }
        public string Username { get; set; }
        public Cart Cart { get; set; }
    }
}