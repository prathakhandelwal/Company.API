using Company.Infrastructure.Repository.Abstractions;
using MediatR;

namespace Company.Application.UseCase.GetUnitCompanyById
{
    public class GetUnitCompanyByIdQueryHandler : IRequestHandler<GetUnitCompanyByIdQuery, CompanyModel?>
    {
        private ICompanyRepository _repository;
        public GetUnitCompanyByIdQueryHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }
        public async Task<CompanyModel?> Handle(GetUnitCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCompanyById(request.Id);
        }
    }
}
