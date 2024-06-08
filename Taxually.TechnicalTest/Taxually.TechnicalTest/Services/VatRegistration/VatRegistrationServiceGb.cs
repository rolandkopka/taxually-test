using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Services.VatRegistration;

public class VatRegistrationServiceGb(IHttpClient httpClient): IVatRegistrationService
{
    public async Task RegisterAsync(VatRegistrationRequest request)
    {
        // UK has an API to register for a VAT number
        await httpClient.PostAsync("https://api.uktax.gov.uk", request);
    }
}