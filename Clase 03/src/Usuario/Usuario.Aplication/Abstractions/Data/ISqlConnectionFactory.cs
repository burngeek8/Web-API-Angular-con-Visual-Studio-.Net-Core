using System.Data.Common;

namespace Usuario.Aplication.Abstractions.Data;

internal interface ISqlConnectionFactory
{
    DbConnection CreateConnection();
}
