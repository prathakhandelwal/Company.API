using Company.Infrastructure.Repository.Abstractions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Application.UseCase.AddUnitCompany
{
    public class AddUnitCompanyCommandHandler : IRequestHandler<AddUnitCompanyCommand,int>
    {
        private ICompanyRepository _repository;
        private readonly IValidator<AddUnitCompanyCommand> _validator;

        public AddUnitCompanyCommandHandler(ICompanyRepository repository
            , IValidator<AddUnitCompanyCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<int> Handle(AddUnitCompanyCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            CompanyModel company = new()
            {
                Name = request.Name,
                Exchange = request.Exchange,
                Isin = request.Isin,
                Ticker = request.Ticker,
                Website = request.Website,
            };
            var result = await _repository.AddCompany(company);

            return result;

        }
    }
}
