using Company.Infrastructure.Repository.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Application.UseCase.GetUnitCompanyByIsin
{
    public class GetUnitCompanyByIsinQuery :IRequest<CompanyModel>
    {
        public string Isin { get; set; }
    }
}
