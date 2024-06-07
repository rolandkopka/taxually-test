using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Services.VatRegistration;

public interface IVatRegistrationServiceFactory
{
    IVatRegistrationService GetService(Country country);
}

public class VatRegistrationServiceFactory(IServiceProvider serviceProvider): IVatRegistrationServiceFactory
{
    public IVatRegistrationService GetService(Country country)
    {
        return country switch
        {
            Country.Gb => serviceProvider.GetRequiredService<VatRegistrationServiceGb>(),
            Country.Fr => serviceProvider.GetRequiredService<VatRegistrationServiceFr>(),
            Country.De => serviceProvider.GetRequiredService<VatRegistrationServiceDe>(),
            _ => throw new Exception("Country not supported")
        };
    }
}