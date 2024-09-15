using Company.Application.Service;
using Company.Application.UseCase.AddUnitCompany;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Company.Application.Extension
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplication
            (this IServiceCollection services) 
        {
            services.AddTransient<IValidator<AddUnitCompanyCommand>, AddUnitCompanyCommandValidator>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssemblies(assembly);
                    //cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                }
                );

            }

            services.AddTransient<ICompanyService, CompanyService>();
            return services;
        }
    }
}
