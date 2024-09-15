using Company.Infrastructure.Repository.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Application.UseCase.GetAllCompany
{
    public class GetAllCompanyQuery :IRequest<List<CompanyModel>>
    {

    }
}
