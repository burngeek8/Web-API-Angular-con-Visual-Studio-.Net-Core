using System.Data.Common;

namespace SistemaComercial.Aplicacion.Abstractions.Data;

public interface ISqlConnectionFactory
{
    DbConnection CreateConnection();
}
