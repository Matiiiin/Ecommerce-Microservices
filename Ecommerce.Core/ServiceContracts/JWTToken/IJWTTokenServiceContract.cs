using Ecommerce.Core.Entities.ApplicationUser;

namespace Ecommerce.Core.ServiceContracts.JWTToken;

public interface IJWTTokenServiceContract
{
    public Task<string> GenerateJWTToken(ApplicationUser user);
}