using Ecommerce.Core.RepositoryContracts.ApplicationUserRepositoryContracts;
using Ecommerce.Infrastructure.Database;
using Ecommerce.Infrastructure.Repositories.ApplicationUserRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<IApplicationUserAdderRepository , ApplicationUserUserAdderRepository>();
        services.AddScoped<IApplicationUserGetterRepository , ApplicationUserGetterRepository>();
        
        services.AddDbContext<ApplicationDbContext>(o =>
        {
            o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
}