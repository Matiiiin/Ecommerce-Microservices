using System.Data;
using System.Data.Common;

namespace Ecommerce.Core.ServiceContracts.Database;

public interface IDapperDbContext
{
    public IDbConnection DbConnection { get; set; }
}