using Company.Infrastructure.Repository.Abstractions;
using Company.Infrastructure.Repository.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Company.Infrastructure.Repository;

public class CompanyRepository : ICompanyRepository
{
    private CompanyContext _dbContext;
    public CompanyRepository(CompanyContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> AddCompany(CompanyModel company)
    {
        _dbContext.Companies.Add(company);
        var result = await _dbContext.SaveChangesAsync();
        var createdCompanyId = _dbContext.Companies.Where(x=> x.Isin == company.Isin).Select(x=> x.Id).FirstOrDefault();
         
        return createdCompanyId;
    }

    public async Task<List<CompanyModel>> GetAll()
    {
        return await _dbContext.Companies.ToListAsync();
    }

    public async Task<CompanyModel?> GetCompanyById(int id)
    {
        return await _dbContext.Companies.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<CompanyModel?> GetCompanyByIsin(string Isin)
    {
        return await _dbContext.Companies.Where(x => x.Isin == Isin).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateCompany(CompanyModel company)
    {
        var updateCompany = await _dbContext.Companies.Where(x=> x.Id == company.Id).FirstOrDefaultAsync();
        if(updateCompany != null)
        {
            updateCompany.Isin = company.Isin;
            updateCompany.Website = company.Website;
            updateCompany.Ticker = company.Ticker;
            updateCompany.Exchange = company.Exchange;
            updateCompany.Name = company.Name;
        }
        _dbContext.Companies.Update(updateCompany);
        var result = await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return true;
        }
        return false;

        
    }
}
