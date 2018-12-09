using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;

namespace WebApplication2.Tests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<WebApplication2.Startup>>
    {
        private readonly WebApplicationFactory<WebApplication2.Startup> _factory;

        public BasicTests(WebApplicationFactory<WebApplication2.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Students")]
        [InlineData("/Students/Create")]
        [InlineData("/Students/Details/1002")]
        [InlineData("/Students/Edit/1002")]
        [InlineData("/Students/Delete/1002")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
            response.Content.Headers.ContentType.ToString());

        }
    }
}
