using Company.Infrastructure.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Company.Infrastructure.Repository.DBContext
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options): base(options) 
        { 
        }

        public DbSet<CompanyModel> Companies { get; set; }
    }
}

