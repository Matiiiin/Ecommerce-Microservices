using System.Data;
using Ecommerce.Core.ServiceContracts.Database;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Ecommerce.Infrastructure.Dapper.Database;

public class DapperDbContext : IDapperDbContext
{
    private readonly IConfiguration _configuration;
    public IDbConnection DbConnection { get; set; }

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        
        var connectionString = _configuration.GetConnectionString("Postgres");
        DbConnection = new NpgsqlConnection(connectionString);
    }
}