using Company.Infrastructure.Repository.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Application.UseCase.GetUnitCompanyByIsin
{
    public class GetUnitCompanyByIsinQueryHandler : IRequestHandler<GetUnitCompanyByIsinQuery, CompanyModel>
    {
        private ICompanyRepository _repository;

        public GetUnitCompanyByIsinQueryHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }
        public async Task<CompanyModel> Handle(GetUnitCompanyByIsinQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCompanyByIsin(request.Isin);
        }
    }
}
