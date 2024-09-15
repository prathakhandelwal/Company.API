using Ardalis.ApiEndpoints;
using Company.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Endpoints
{
    public class GetUnitCompanyByIdEndpoint : EndpointBaseAsync
        .WithRequest<int>
        .WithActionResult<GetUnitCompanyResponse>
    {
        public ICompanyService _companyService;
        public GetUnitCompanyByIdEndpoint(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("unit-company/id/{id}")]
        [ProducesResponseType(200, Type = typeof(GetUnitCompanyResponse))]
        [Produces("application/Json")]
        public override async Task<ActionResult<GetUnitCompanyResponse>> HandleAsync(
            [FromRoute] int id,
            CancellationToken cancellationToken = new())
        {
            var response = await _companyService.GetUnitCompanyById(new GetUnitCompanyByIdRequest { Id = id}, cancellationToken);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
