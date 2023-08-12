using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineLibrary.Application.Common.Interfaces;
using OnlineLibrary.Infrastructure.Persistence;

namespace OnlineLibrary.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DbConnect"));
            options.UseLazyLoadingProxies();
        });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        //  services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        return services;
    }
}
