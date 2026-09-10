using Dapper;
using Ecommerce.Core.Entities.ApplicationUser;
using Ecommerce.Core.RepositoryContracts.ApplicationUserRepositoryContracts;
using Ecommerce.Core.ServiceContracts.Database;
using Ecommerce.Infrastructure.Dapper.Database;
using Ecommerce.Infrastructure.EF_Core.Database;

namespace Ecommerce.Infrastructure.Dapper.Repositories.ApplicationUserRepositories;

public class ApplicationUserUserAdderRepository : IApplicationUserAdderRepository
{
    private readonly IDapperDbContext _db;

    public ApplicationUserUserAdderRepository(IDapperDbContext db)
    {
        _db = db;
    }
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        var inserted = await _db.DbConnection.ExecuteAsync(
            "INSERT INTO USERS (userId, email, password, personName, gender) " +
            "VALUES (@UserId, @Email, @Password, @PersonName, @Gender)",
            user);
        if (inserted > 0)
        {
            return user;
        }
       return null;
    }
}