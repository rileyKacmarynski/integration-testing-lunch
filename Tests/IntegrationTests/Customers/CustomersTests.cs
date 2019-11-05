using Core.Dtos;
using Infrastructure.Database;
using IntegrationTests.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Core.Services;

namespace IntegrationTests.Customers
{
    [TestFixture]
    public class CustomersTests
    {
        private HttpClient _client;
        private WebApplicationFactory<Startup> _factory;

        [OneTimeSetUp]
        public void Init()
        {
            _factory = new ApiWebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(options =>
                    {

                    });
                });

            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        private async Task<HttpResponseMessage> PostAsync(string url, object values)
        {
            var json = JsonConvert.SerializeObject(values);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(url, content).ConfigureAwait(false);
        }

        private async Task<HttpResponseMessage> GetAsync(string url) =>
            await _client.GetAsync(url).ConfigureAwait(false);

        [Test]
        public async Task AddItemToCart_ItemAdded_ReturnsSuccess()
        {
            // we need a customer and product with ID 1.
            var customerId = 1;
            var request = new AddItemToCartRequest
            {
                Price = 19.99m,
                Quantity = 2,
                ProductId = 1,
                CustomerId = 1
            };

            var resp = await PostAsync($"api/customers/{customerId}/cart", request);

            Assert.That(resp.IsSuccessStatusCode);
        }
    }
}
