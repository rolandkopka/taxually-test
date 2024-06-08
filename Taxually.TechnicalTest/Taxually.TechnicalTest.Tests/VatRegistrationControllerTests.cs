using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Taxually.TechnicalTest.Controllers;
using Taxually.TechnicalTest.Models;
using Taxually.TechnicalTest.Services.VatRegistration;

namespace Taxually.TechnicalTest.Tests;

public class VatRegistrationControllerTests
{
    [Fact]
    public async Task Post_WithValidRequest_CallsRegisterAsyncAndReturnsOk()
    {
        // Arrange
        var mockServiceFactory = Substitute.For<IVatRegistrationServiceFactory>();
        var mockService = Substitute.For<IVatRegistrationService>();
        var controller = new VatRegistrationController(mockServiceFactory);
        var request = new VatRegistrationRequest
        {
            Country = Country.Gb,
            CompanyName = "Test Company",
            CompanyId = "12345678"
        };

        mockServiceFactory.GetService(Arg.Any<Country>()).Returns(mockService);
        mockService.RegisterAsync(Arg.Any<VatRegistrationRequest>()).Returns(Task.CompletedTask);

        // Act
        var result = await controller.Post(request);
        
        // Assert
        await mockService.Received(1).RegisterAsync(Arg.Is<VatRegistrationRequest>(x => x == request));
        Assert.IsType<OkResult>(result);
    }
}