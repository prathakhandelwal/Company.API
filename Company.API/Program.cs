using Company.API.Extensions;
using Company.Application.Extension;
using Company.Infrastructure.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Company.API;
public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        const int listenPort1 = 5001;
        const int listenPort2 = 5002;

        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(listenPort1, listenOptions => listenOptions.Protocols = HttpProtocols.Http1);
            options.ListenAnyIP(listenPort2, listenOptions => listenOptions.Protocols = HttpProtocols.Http2);
        });

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var configBuilder = new ConfigurationBuilder()
                           .SetBasePath(builder.Environment.ContentRootPath)
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                           .AddJsonFile("appsetting." + builder.Environment + ".json", optional: true).AddEnvironmentVariables();

        IConfiguration config = configBuilder.Build();
        builder.Services
            .ConfigureApi()
            .ConfigureApplication()
            .ConfigureRespository(builder.Configuration);

        var app = builder.Build();


        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}


