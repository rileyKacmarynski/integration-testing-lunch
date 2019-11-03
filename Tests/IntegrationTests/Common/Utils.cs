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
            var customer = new Customer("Riley");
            var order = new Order(customer);
            dbContext.Orders.Add(order);

            await dbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
