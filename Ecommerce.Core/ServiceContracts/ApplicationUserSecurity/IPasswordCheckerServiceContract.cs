using Ecommerce.Core.Entities.ApplicationUser;

namespace Ecommerce.Core.ServiceContracts.ApplicationUserSecurity;

public interface IPasswordCheckerServiceContract
{
    public Task<bool> CheckPassword(ApplicationUser user, string password);
}