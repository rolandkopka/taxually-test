using NSubstitute;
using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.Models;
using Taxually.TechnicalTest.Services.VatRegistration;

namespace Taxually.TechnicalTest.Tests.UnitTests.Services;

public class VatRegistrationServiceGbTests
{
    [Fact]
    public async Task RegisterAsync_CallsHttpClientPostAsync()
    {
        // Arrange
        var httpClient = Substitute.For<IHttpClient>();
        var service = new VatRegistrationServiceGb(httpClient);
        var request = new VatRegistrationRequest
        {
            Country = Country.Gb,
            CompanyName = "Test Company",
            CompanyId = "12345678"
        };
        // Act
        await service.RegisterAsync(request);

        // Assert
        await httpClient.Received().PostAsync("https://api.uktax.gov.uk", request);
    }
}