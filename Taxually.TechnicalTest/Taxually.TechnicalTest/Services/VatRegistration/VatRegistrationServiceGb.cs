using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.Controllers;

namespace Taxually.TechnicalTest.Services.VatRegistration;

public class VatRegistrationServiceGb: IVatRegistrationService
{
    public async Task RegisterAsync(VatRegistrationRequest request)
    {
        // UK has an API to register for a VAT number
        var httpClient = new TaxuallyHttpClient();
        await httpClient.PostAsync("https://api.uktax.gov.uk", request);
    }
}