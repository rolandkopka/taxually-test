using System.Xml.Serialization;
using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Services.VatRegistration;

public class VatRegistrationServiceDe(IQueueClient xmlQueueClient): IVatRegistrationService
{
    public async Task RegisterAsync(VatRegistrationRequest request)
    {
        // Germany requires an XML document to be uploaded to register for a VAT number
        await using (var stringwriter = new StringWriter())
        {
            var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
            serializer.Serialize(stringwriter, request);
            var xml = stringwriter.ToString();
            // Queue xml doc to be processed
            await xmlQueueClient.EnqueueAsync("vat-registration-xml", xml);
        }
    }
}