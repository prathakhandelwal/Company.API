namespace Company.Application.Service
{
    public interface ICompanyService
    {
        Task<AddUnitCompanyResponse> AddUnitCompany(AddUnitCompanyRequest company, CancellationToken cancellationToken);
        Task<GetUnitCompanyResponse> GetUnitCompanyById(GetUnitCompanyByIdRequest request, CancellationToken cancellationToken);
        Task<GetUnitCompanyResponse> GetCompanyByIsin(GetUnitCompanyByIsinRequest request, CancellationToken cancellationToken);
        Task<GetAllCompanyResponse> GetAll(CancellationToken cancellationToken);
        Task<UpdateUnitCompanyResponse> UpdateCompany(UpdateUnitCompanyRequest company, CancellationToken cancellationToken);
    }
}
