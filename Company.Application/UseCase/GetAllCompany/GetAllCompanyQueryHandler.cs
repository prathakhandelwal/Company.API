using Company.Infrastructure.Repository.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Company.Application.UseCase.GetAllCompany
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, List<CompanyModel>>
    {
        private ICompanyRepository _repository;

        public GetAllCompanyQueryHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<CompanyModel>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();

            return result;
        }
    }
}
