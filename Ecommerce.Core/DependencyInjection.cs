using Ecommerce.Core.Options;
using Ecommerce.Core.ServiceContracts.ApplicationUserSecurity;
using Ecommerce.Core.ServiceContracts.Authentication;
using Ecommerce.Core.ServiceContracts.JWTToken;
using Ecommerce.Core.Services.ApplicationUserSecurity;
using ECommerce.Core.Services.Authentication;
using Ecommerce.Core.Services.JWTToken;
using Ecommerce.Core.Validators.DTO.AuthenticationDTO;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Ecommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<IPasswordCheckerServiceContract, PasswordCheckerService>();
        services.AddScoped<IAuthenticationServiceContract, AuthenticationService>();
        services.AddScoped<IJWTTokenServiceContract, JWTTokenService>();
        services.AddValidatorsFromAssemblyContaining<RegistrationDTOValidator>();
        services.AddFluentValidationAutoValidation();

        
        
        services.Configure<JWTOptions>(
            configuration.GetSection("Jwt"));
        return services;
    }
}