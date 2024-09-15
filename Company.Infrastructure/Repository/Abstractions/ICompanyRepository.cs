using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Infrastructure.Repository.Abstractions
{
    public interface ICompanyRepository
    {
        Task<int> AddCompany(CompanyModel company);
        Task<CompanyModel?> GetCompanyById(int id);
        Task<CompanyModel?> GetCompanyByIsin(string Isin);
        Task<List<CompanyModel>> GetAll();
        Task<bool> UpdateCompany(CompanyModel company);
    }
}
