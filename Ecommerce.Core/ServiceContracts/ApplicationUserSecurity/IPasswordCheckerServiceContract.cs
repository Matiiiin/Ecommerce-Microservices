using Ecommerce.Core.Entities.ApplicationUser;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Core.ServiceContracts.ApplicationUserSecurity;

public interface IPasswordCheckerServiceContract
{
    public Task<PasswordVerificationResult> CheckPassword(ApplicationUser user, string password);
}