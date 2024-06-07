using System.Text;
using Taxually.TechnicalTest.Controllers;

namespace Taxually.TechnicalTest.Services.VatRegistration;

public class VatRegistrationServiceFr : IVatRegistrationService
{
    public async Task RegisterAsync(VatRegistrationRequest request)
    {
        // France requires an excel spreadsheet to be uploaded to register for a VAT number
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("CompanyName,CompanyId");
        csvBuilder.AppendLine($"{request.CompanyName}{request.CompanyId}");
        var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
        var excelQueueClient = new TaxuallyQueueClient();
        // Queue file to be processed
        await excelQueueClient.EnqueueAsync("vat-registration-csv", csv);
    }
}