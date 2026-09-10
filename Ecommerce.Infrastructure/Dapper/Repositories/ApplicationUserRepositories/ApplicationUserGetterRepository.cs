using Dapper;
using Ecommerce.Core.Entities.ApplicationUser;
using Ecommerce.Core.RepositoryContracts.ApplicationUserRepositoryContracts;
using Ecommerce.Core.ServiceContracts.Database;
using Ecommerce.Infrastructure.Dapper.Database;
using Ecommerce.Infrastructure.EF_Core.Database;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Dapper.Repositories.ApplicationUserRepositories;

public class ApplicationUserGetterRepository : IApplicationUserGetterRepository
{
    private readonly IDapperDbContext _db;

    public ApplicationUserGetterRepository(IDapperDbContext db)
    {
        _db = db;
    }
    public async Task<ApplicationUser?> GetUserByEmail(string? email)
    {
        ApplicationUser user = (await _db.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(
            "SELECT * FROM USERS WHERE email = @email;",
            new { email }))!;
        return user;
    }
}