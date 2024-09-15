using Company.Infrastructure.Repository;
using Company.Infrastructure.Repository.Abstractions;
using Company.Infrastructure.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureRespository
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionStrings:CompanyContext").Value;
            services.AddTransient<ICompanyRepository,CompanyRepository>();
            services.AddDbContext<CompanyContext>(options =>
                   options.UseSqlServer(connectionString));
            return services;
        }
    }
}
