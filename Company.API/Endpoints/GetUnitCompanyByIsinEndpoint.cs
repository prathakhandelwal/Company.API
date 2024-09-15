using Ardalis.ApiEndpoints;
using Company.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Endpoints
{    public class GetUnitCompanyByIsinEndpoint : EndpointBaseAsync
        .WithRequest<string>
        .WithActionResult<GetUnitCompanyResponse>
    {
        public ICompanyService _companyService;
        public GetUnitCompanyByIsinEndpoint(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("unit-company/{isin}")]
        [ProducesResponseType(200, Type = typeof(GetUnitCompanyResponse))]
        [Produces("application/Json")]
        public override async Task<ActionResult<GetUnitCompanyResponse>> HandleAsync(
            [FromRoute] string isin,
            CancellationToken cancellationToken = new())
        {
            var response = await _companyService.GetCompanyByIsin(new GetUnitCompanyByIsinRequest { Isin = isin},cancellationToken);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
