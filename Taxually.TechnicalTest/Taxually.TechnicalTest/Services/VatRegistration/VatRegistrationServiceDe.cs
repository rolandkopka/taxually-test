using System.Xml.Serialization;
using Taxually.TechnicalTest.Controllers;

namespace Taxually.TechnicalTest.Services.VatRegistration;

public class VatRegistrationServiceDe: IVatRegistrationService
{
    public async Task RegisterAsync(VatRegistrationRequest request)
    {
        // Germany requires an XML document to be uploaded to register for a VAT number
        await using (var stringwriter = new StringWriter())
        {
            var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
            serializer.Serialize(stringwriter, this);
            var xml = stringwriter.ToString();
            var xmlQueueClient = new TaxuallyQueueClient();
            // Queue xml doc to be processed
            await xmlQueueClient.EnqueueAsync("vat-registration-xml", xml);
        }
    }
}