using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Services.VatRegistration;

public interface IVatRegistrationService
{
    Task RegisterAsync(VatRegistrationRequest request);
}