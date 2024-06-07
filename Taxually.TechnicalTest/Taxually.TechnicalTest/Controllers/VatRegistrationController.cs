using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Services.VatRegistration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController: ControllerBase
    {
        private readonly IVatRegistrationService _vatRegistrationServiceGb;
        private readonly IVatRegistrationService _vatRegistrationServiceFr;
        private readonly IVatRegistrationService _vatRegistrationServiceDe;
        
        VatRegistrationController(IVatRegistrationService vatRegistrationServiceGb, IVatRegistrationService vatRegistrationServiceFr,
                        IVatRegistrationService vatRegistrationServiceDe)
        {
            _vatRegistrationServiceGb = vatRegistrationServiceGb;
            _vatRegistrationServiceFr = vatRegistrationServiceFr;
            _vatRegistrationServiceDe = vatRegistrationServiceDe;
        }

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
        {
            switch (request.Country)
            {
                case "GB":
                    await _vatRegistrationServiceGb.RegisterAsync(request);
                    break;
                case "FR":
                    await _vatRegistrationServiceFr.RegisterAsync(request);
                    break;
                case "DE":
                    await _vatRegistrationServiceDe.RegisterAsync(request);
                    break;
                default:
                    throw new Exception("Country not supported");

            }
            return Ok();
        }
    }

    public class VatRegistrationRequest
    {
        public string CompanyName { get; set; }
        public string CompanyId { get; set; }
        public string Country { get; set; }
    }
}
