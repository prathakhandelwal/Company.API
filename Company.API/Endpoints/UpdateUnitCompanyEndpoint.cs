using Ardalis.ApiEndpoints;
using Company.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.API.Endpoints
{
    public class UpdateUnitCompanyEndpoint : EndpointBaseAsync
        .WithRequest<UpdateUnitCompanyRequest>
        .WithActionResult<UpdateUnitCompanyResponse>
    {
        public ICompanyService _companyService;
        public UpdateUnitCompanyEndpoint(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("unit-company/update")]
        [ProducesResponseType(200, Type = typeof(UpdateUnitCompanyResponse))]
        [Produces("application/Json")]
        public override async Task<ActionResult<UpdateUnitCompanyResponse>> HandleAsync(
            [FromBody] UpdateUnitCompanyRequest request,
            CancellationToken cancellationToken = new())
        {
            var response = await _companyService.UpdateCompany(request,cancellationToken);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
