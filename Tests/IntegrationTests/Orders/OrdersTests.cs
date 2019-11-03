using System.Net;
using System.Threading.Tasks;
using Core.Dtos;
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
        public async Task GetOrder_OrderFound_ReturnsSuccess()
        {
            // act
            var response = await GetAsync("api/orders/1");

            // assert
            Assert.That(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task GetOrder_OrderNotFound_ReturnsNotFound()
        {
            var response = await GetAsync("api/orders/-1");

            Assert.That(response.StatusCode == HttpStatusCode.NotFound);
        }

        [Test]
        public async Task CreateOrder_Valid_CreatesOrder()
        {
            // arrange
            var orderRequest = new CreateOrderRequest { CartId = 2 };

            // act
            var response = await PostAsync("api/orders", orderRequest);

            // assert
            Assert.That(response.IsSuccessStatusCode);
        }
    }
}