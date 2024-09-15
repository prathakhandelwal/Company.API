using Microsoft.AspNetCore.Mvc;
using Ardalis.ApiEndpoints;
using Company.Application.Service;

namespace Company.API.Endpoints
{
    public class AddUnitCompanyEndpoint : EndpointBaseAsync
        .WithRequest<AddUnitCompanyRequest>
        .WithActionResult<AddUnitCompanyResponse>
    {
        public ICompanyService _companyService;
        public AddUnitCompanyEndpoint(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("unit-company/add")]
        [ProducesResponseType(200, Type = typeof(AddUnitCompanyResponse))]
        [Produces("application/Json")]
        public override async Task<ActionResult<AddUnitCompanyResponse>> HandleAsync(
            [FromBody] AddUnitCompanyRequest request,
            CancellationToken cancellationToken = new())
        {
            var response = await _companyService.AddUnitCompany(request, cancellationToken);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
