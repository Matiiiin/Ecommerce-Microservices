using Ecommerce.Core.Entities.ApplicationUser;

namespace Ecommerce.Core.RepositoryContracts.ApplicationUserRepositoryContracts;

public interface IApplicationUserGetterRepository
{
    public Task<ApplicationUser?> GetUserByEmailAndPassword(string? email ,string? password);
}