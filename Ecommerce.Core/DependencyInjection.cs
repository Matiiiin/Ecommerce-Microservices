using Ecommerce.Core.Options;
using Ecommerce.Core.ServiceContracts.ApplicationUserSecurity;
using Ecommerce.Core.ServiceContracts.Authentication;
using Ecommerce.Core.ServiceContracts.JWTToken;
using Ecommerce.Core.Services.ApplicationUserSecurity;
using ECommerce.Core.Services.Authentication;
using Ecommerce.Core.Services.JWTToken;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<IPasswordCheckerServiceContract, PasswordCheckerService>();
        services.AddScoped<IAuthenticationServiceContract, AuthenticationService>();
        services.AddScoped<IJWTTokenServiceContract, JWTTokenService>();
        
        
        
        services.Configure<JWTOptions>(
            configuration.GetSection("Jwt"));
        return services;
    }
}