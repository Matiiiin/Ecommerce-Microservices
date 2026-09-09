using Ecommerce.Core.Entities.ApplicationUser;
using Ecommerce.Core.ServiceContracts.ApplicationUserSecurity;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Core.Services.ApplicationUserSecurity;

public class PasswordCheckerService : IPasswordCheckerServiceContract
{
    public Task<PasswordVerificationResult> CheckPassword(ApplicationUser user, string password)
    {
        var result = new PasswordHasher<ApplicationUser>().VerifyHashedPassword(user,user.Password , password);
        return Task.FromResult(result);
    }
}