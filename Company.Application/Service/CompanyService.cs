using Company.Application.UseCase.AddUnitCompany;
using Company.Application.UseCase.GetAllCompany;
using Company.Application.UseCase.GetUnitCompanyById;
using Company.Application.UseCase.GetUnitCompanyByIsin;
using Company.Application.UseCase.UpdateUnitCompany;
using Company.Infrastructure.Repository.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Company.Application.Service
{
    public class CompanyService : ICompanyService
    {
        public IMediator _mediator;
        public ILogger<CompanyService> _logger;

        public CompanyService(IMediator mediator, ILogger<CompanyService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        public async Task<AddUnitCompanyResponse> AddUnitCompany(AddUnitCompanyRequest company, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send<int>(new AddUnitCompanyCommand
                {
                    Name = company.Name,
                    Exchange = company.Exchange,
                    Isin = company.Isin,
                    Ticker = company.Ticker,
                    Website = company.Website,

                });

                return new AddUnitCompanyResponse
                {
                    Id = result,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Add Unit Error", ex);
                return new AddUnitCompanyResponse
                {
                    Id = -1,
                };
            }
        }

        public async Task<GetAllCompanyResponse> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send<List<CompanyModel>>(new GetAllCompanyQuery());

            var response = new GetAllCompanyResponse();

            foreach (var company in result)
            {
                response.Items.Add(new UnitCompany
                {
                    Id= company.Id,
                    Name = company.Name,
                    Exchange = company.Exchange,
                    Isin = company.Isin,
                    Ticker = company.Ticker,
                    Website = company.Website,
                });
            }
            return response;
        }

        public async Task<GetUnitCompanyResponse> GetCompanyByIsin(GetUnitCompanyByIsinRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send<CompanyModel>(new GetUnitCompanyByIsinQuery 
            { 
                Isin = request.Isin             
            });

            if(result != null)
            {
                var response = new GetUnitCompanyResponse()
                {
                    Item = new UnitCompany
                    {
                        Id = result.Id,
                        Name = result.Name,
                        Exchange = result.Exchange,
                        Isin = result.Isin,
                        Ticker = result.Ticker,
                        Website = result.Website,
                    }
                };
                return response;
            }
            return new GetUnitCompanyResponse();
        }

        public async Task<GetUnitCompanyResponse> GetUnitCompanyById(GetUnitCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send<CompanyModel>(new GetUnitCompanyByIdQuery
            { 
                Id = request.Id 
            });

            return new GetUnitCompanyResponse()
            {
                Item = new UnitCompany
                {
                    Id = result.Id,
                    Name = result.Name,
                    Exchange = result.Exchange,
                    Isin = result.Isin,
                    Ticker = result.Ticker,
                    Website = result.Website,
                }
            };
        }

        public async Task<UpdateUnitCompanyResponse> UpdateCompany(UpdateUnitCompanyRequest company, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send<bool>(new UpdateUnitCompanyQuery
            {
                Id = company.Id,
                Name = company.Name,
                Exchange = company.Exchange,
                Isin = company.Isin,
                Ticker = company.Ticker,
                Website = company.Website,
            });

            return new UpdateUnitCompanyResponse()
            {
                IsUpdate = result
            };
        }
    }
}
