using Ecommerce.Core.Entities.ApplicationUser;
using Ecommerce.Core.RepositoryContracts.ApplicationUserRepositoryContracts;
using Ecommerce.Infrastructure.Database;

namespace Ecommerce.Infrastructure.Repositories.ApplicationUserRepositories;

public class ApplicationUserUserAdderRepository : IApplicationUserAdderRepository
{
    private readonly ApplicationDbContext _db;

    public ApplicationUserUserAdderRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        
        await _db.ApplicationUsers.AddAsync(user);
        await _db.SaveChangesAsync();
        return user;
    }
}