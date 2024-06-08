using System.Xml.Linq;
using NSubstitute;
using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.Models;
using Taxually.TechnicalTest.Services.VatRegistration;

namespace Taxually.TechnicalTest.Tests.Services;

public class VatRegistrationServiceDeTests
{
    [Fact]
    public async Task RegisterAsync_CallsEnqueueAsyncWithCorrectParameters()
    {
        // Arrange
        var queueClient = Substitute.For<IQueueClient>();
        var service = new VatRegistrationServiceDe(queueClient);
        var request = new VatRegistrationRequest
        {
            Country = Country.De,
            CompanyName = "Test Company",
            CompanyId = "12345678"
        };

        // Act
        await service.RegisterAsync(request);

        // Assert
        await queueClient.Received(1).EnqueueAsync(
            Arg.Is<string>(s => s == "vat-registration-xml"),
            Arg.Is<string>(s => IsValidXml(s, request)));
    }
    
    private static bool IsValidXml(string xml, VatRegistrationRequest request)
    {
        var doc = XDocument.Parse(xml);
        var root = doc.Root;

        if (root == null || root.Name != "VatRegistrationRequest")
        {
            return false;
        }

        var xmlCompanyName = root.Element("CompanyName")?.Value;
        var xmlCompanyId = root.Element("CompanyId")?.Value;
        var xmlCountry = root.Element("Country")?.Value;

        return xmlCompanyName == request.CompanyName &&
               xmlCompanyId == request.CompanyId &&
               xmlCountry == request.Country.ToString();
    }
}