using Ecommerce.Core.Entities.ApplicationUser;

namespace Ecommerce.Core.RepositoryContracts.ApplicationUserRepositoryContracts;

public interface IApplicationUserAdderRepository
{
    public Task<ApplicationUser?> AddUserAsync(ApplicationUser user);
}