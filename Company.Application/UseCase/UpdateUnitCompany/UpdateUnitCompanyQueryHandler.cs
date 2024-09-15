using Company.Infrastructure.Repository.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Application.UseCase.UpdateUnitCompany
{
    public class UpdateUnitCompanyQueryHandler : IRequestHandler<UpdateUnitCompanyQuery, bool>
    {
        private ICompanyRepository _repository;

        public UpdateUnitCompanyQueryHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateUnitCompanyQuery request, CancellationToken cancellationToken)
        {
            CompanyModel company = new()
            {
                Id = request.Id,
                Name = request.Name,
                Exchange = request.Exchange,
                Isin = request.Isin,
                Ticker = request.Ticker,
                Website = request.Website,
            };

            return await _repository.UpdateCompany(company);
        }
    }
}
