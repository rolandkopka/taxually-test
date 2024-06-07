using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Models;
using Taxually.TechnicalTest.Services.VatRegistration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VatRegistrationController(
                IVatRegistrationService vatRegistrationServiceGb,
                IVatRegistrationService vatRegistrationServiceFr,
                IVatRegistrationService vatRegistrationServiceDe)
                : ControllerBase
{
    /// <summary>
    /// Registers a company for a VAT number in a given country
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
    {
        switch (request.Country)
        {
            case Country.Gb:
                await vatRegistrationServiceGb.RegisterAsync(request);
                break;
            case Country.Fr:
                await vatRegistrationServiceFr.RegisterAsync(request);
                break;
            case Country.De:
                await vatRegistrationServiceDe.RegisterAsync(request);
                break;
            default:
                throw new Exception("Country not supported");

        }
        return Ok();
    }
}