using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace medicationApi.Tests
{
    public class MedicineControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public MedicineControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllMedicine_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/medicine");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}