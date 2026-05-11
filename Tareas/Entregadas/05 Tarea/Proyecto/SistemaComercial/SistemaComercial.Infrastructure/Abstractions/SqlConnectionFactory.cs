using System.Data.Common;
using SistemaComercial.Aplicacion.Abstractions.Data;
using Npgsql;

namespace SistemaComercial.Infrastructure.Abstractions;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}
