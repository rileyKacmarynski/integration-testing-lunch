using Core.Entities;
using Core.Entities.OrderEntity;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationTests.Common
{
    public static class Utils
    {
        public static async Task SeedDatabase(IThingShopDbContext dbContext)
        {
            dbContext.Products.Add(new Product
            {
                Description = "A Swingline",
                Name = "Stapler",
                Price = 3.5m
            });

            dbContext.Products.Add(new Product
            {
                Description = "Blue switches, perfect for annoying coworkers",
                Name = "Mechanical Keyboard",
                Price = 89.99m
            });

            var orderProduct = new Product
            {
                Description = "That's a lot of pixels.",
                Name = "4k Monitor",
                Price = 299.99m
            };
            dbContext.Products.Add(orderProduct);

            var customer = new Customer("Riley");
            var order = new Order(customer);
            dbContext.Orders.Add(order);

            var orderTester = new Customer("OrderTester");
            orderTester.AddItemToCart(orderProduct);
            dbContext.Customers.Add(orderTester);

            await dbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
