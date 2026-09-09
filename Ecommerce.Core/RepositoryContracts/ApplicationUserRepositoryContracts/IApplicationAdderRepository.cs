using Ecommerce.Core.Entities.ApplicationUser;

namespace Ecommerce.Core.RepositoryContracts.ApplicationUserRepositoryContracts;

public interface IApplicationAdderRepository
{
    public Task<ApplicationUser?> AddUserAsync(ApplicationUser user);
}