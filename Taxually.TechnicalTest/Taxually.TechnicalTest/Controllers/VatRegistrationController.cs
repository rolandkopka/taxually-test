using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Models;
using Taxually.TechnicalTest.Services.VatRegistration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VatRegistrationController(IVatRegistrationServiceFactory vatRegistrationServiceFactory): ControllerBase
{
    /// <summary>
    /// Registers a company for a VAT number in a given country
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
    {
        var service = vatRegistrationServiceFactory.GetService(request.Country);
        await service.RegisterAsync(request);
        return Ok();
    }
}