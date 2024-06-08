using NSubstitute;
using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.Models;
using Taxually.TechnicalTest.Services.VatRegistration;

namespace Taxually.TechnicalTest.Tests.Services;

public class VatRegistrationServiceFrTests
{
    [Fact]
    public async Task RegisterAsync_CallsQueueClientEnqueueAsync()
    {
        // Arrange
        var queueClient = Substitute.For<IQueueClient>();
        var service = new VatRegistrationServiceFr(queueClient);
        var request = new VatRegistrationRequest
        {
            Country = Country.Fr,
            CompanyName = "Test Company",
            CompanyId = "12345678"
        };

        // Act
        await service.RegisterAsync(request);

        // Assert
        await queueClient.Received().EnqueueAsync("vat-registration-csv", Arg.Any<byte[]>());
    }
}