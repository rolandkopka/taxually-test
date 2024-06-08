using System.Text;
using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Services.VatRegistration;

public class VatRegistrationServiceFr(IQueueClient excelQueueClient) : IVatRegistrationService
{
    public async Task RegisterAsync(VatRegistrationRequest request)
    {
        // France requires an excel spreadsheet to be uploaded to register for a VAT number
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("CompanyName,CompanyId");
        csvBuilder.AppendLine($"{request.CompanyName}{request.CompanyId}");
        var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
        // Queue file to be processed
        await excelQueueClient.EnqueueAsync("vat-registration-csv", csv);
    }
}