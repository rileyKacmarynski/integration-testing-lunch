using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderEntity;
using Core.Interfaces;
using IntegrationTests.Common;
using NUnit.Framework;

namespace IntegrationTests.Orders
{
    [TestFixture]
    public class OrdersTests : BaseApiTest
    {
        [Test]
        public async Task GetOrderById()
        {
            // act
            var response = await GetAsync("api/orders/1");

            // assert
            Assert.That(response.IsSuccessStatusCode);
        }
    }
}