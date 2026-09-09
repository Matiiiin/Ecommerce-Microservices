using Ecommerce.Core.Entities.ApplicationUser;
using Ecommerce.Core.RepositoryContracts.ApplicationUserRepositoryContracts;
using Ecommerce.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories.ApplicationUserRepositories;

public class ApplicationUserGetterRepository : IApplicationUserGetterRepository
{
    private readonly ApplicationDbContext _db;

    public ApplicationUserGetterRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public Task<ApplicationUser?> GetUserByEmail(string? email)
    {
        return _db.ApplicationUsers.SingleOrDefaultAsync(user => user.Email == email);
    }
}