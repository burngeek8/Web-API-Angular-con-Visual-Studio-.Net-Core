using System.Data.Common;

namespace Usuario.Aplication.Abstractions.Data;

public interface ISqlConnectionFactory
{
    DbConnection CreateConnection();
}
