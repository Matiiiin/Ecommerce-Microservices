using Ecommerce.Core.RepositoryContracts.ApplicationUserRepositoryContracts;
using Ecommerce.Core.ServiceContracts.Database;
using Ecommerce.Infrastructure.Dapper;
using Ecommerce.Infrastructure.Dapper.Database;
using Ecommerce.Infrastructure.Dapper.Repositories.ApplicationUserRepositories;
using Ecommerce.Infrastructure.EF_Core.Database;
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
        services.AddScoped<IDapperDbContext , DapperDbContext>();
        
        services.AddDbContext<ApplicationDbContext>(o =>
        {
            o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
}