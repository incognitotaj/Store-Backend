using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Store.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions.Data;

namespace Store.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
        services
        .AddDatabase(configuration)
        .AddAuthenticationInternal()
        .AddAuthorizationInternal();

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<ApiDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApiDbContext>(sp=>sp.GetRequiredService<ApiDbContext>());

        return services;
    }

    public static IServiceCollection AddAuthenticationInternal(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddAuthorizationInternal(this IServiceCollection services)
    {
        services.AddAuthorization();
        return services;
    }
}
