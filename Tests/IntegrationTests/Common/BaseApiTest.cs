using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using Web;

namespace IntegrationTests.Common
{
    [TestFixture]
    public class BaseApiTest
    {
        private HttpClient _client;
        private WebApplicationFactory<Startup> _factory;

        [OneTimeSetUp]
        public void Init()
        {
            _factory = new ApiWebApplicationFactory<Startup>()
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        protected async Task<HttpResponseMessage> PostAsync(string url, object values)
        {
            var json = JsonConvert.SerializeObject(values);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(url, content).ConfigureAwait(false);
        }

        protected async Task<HttpResponseMessage> GetAsync(string url) =>
            await _client.GetAsync(url).ConfigureAwait(false);
    }
}