using System.Data.Common;
using Usuario.Aplication.Abstractions.Data;

namespace Usuario.Infrastructure.Abstractions;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbConnection CreateConnection()
    {
        var connection = new Npgsql.NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}
