using Taxually.TechnicalTest.Controllers;

namespace Taxually.TechnicalTest.Services.VatRegistration;

public interface IVatRegistrationService
{
    Task RegisterAsync(VatRegistrationRequest request);
}