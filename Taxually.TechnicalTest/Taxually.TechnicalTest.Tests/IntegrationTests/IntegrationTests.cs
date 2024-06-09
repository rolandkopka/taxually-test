using Microsoft.AspNetCore.Mvc.Testing;

namespace Taxually.TechnicalTest.Tests.IntegrationTests;

public class IntegrationTests(WebApplicationFactory<Program> factory): IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Theory]
    [InlineData("Gb")]
    [InlineData("Fr")]
    [InlineData("De")]
    public async Task Post_VatRegistration_ReturnsOk(string country)
    {
        // Arrange
        var url = "/api/vatregistration";
        var requestJson = $"{{\"CompanyName\":\"Test Company\",\"CompanyId\":\"123456\",\"Country\":\"{country}\"}}";
        var content = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync(url, content);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
    }

    [Theory]
    [InlineData("{\"CompanyId\":\"123456\",\"Country\":\"Gb\"}")]
    [InlineData("{\"CompanyName\":\"Test Company\",\"Country\":\"Gb\"}")]
    [InlineData("{\"CompanyName\":\"Test Company\",\"CompanyId\":\"123456\"}")]
    public async Task Post_VatRegistration_ReturnsBadRequest_WhenRequiredFieldIsMissing(string requestJson)
    {
        // Arrange
        var url = "/api/vatregistration";
        var content = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync(url, content);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task Post_VatRegistration_ReturnsBadRequest_WhenCountryIsInvalid()
    {
        // Arrange
        var url = "/api/vatregistration";
        var requestJson = "{\"CompanyName\":\"Test Company\",\"CompanyId\":\"123456\",\"Country\":\"Invalid\"}";
        var content = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync(url, content);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }
}