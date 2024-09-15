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
    public class GetAllCompanyEndpoint : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<GetAllCompanyResponse>
    {
        public ICompanyService _companyService;
        public GetAllCompanyEndpoint(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("unit-company/get-all")]
        [ProducesResponseType(200, Type = typeof(GetAllCompanyRequest))]
        [Produces("application/Json")]
        public override async Task<ActionResult<GetAllCompanyResponse>> HandleAsync(
            CancellationToken cancellationToken = new())
        {
            var response = await _companyService.GetAll( cancellationToken);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
