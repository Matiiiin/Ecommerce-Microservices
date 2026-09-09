using Ecommerce.Core.Entities.ApplicationUser;
using Ecommerce.Core.ServiceContracts.ApplicationUserSecurity;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Core.Services.ApplicationUserSecurity;

public class PasswordCheckerService : IPasswordCheckerServiceContract
{
    public Task<bool> CheckPassword(ApplicationUser user, string password)
    {
        var hashedPassword = new PasswordHasher<ApplicationUser>().HashPassword(user , password);
        return Task.FromResult(hashedPassword == password);
    }
}