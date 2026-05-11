using System.Data.Common;

namespace Empleado.Aplicacion.Abstractions.Data;

public interface ISqlConnectionFactory
{
    DbConnection CreateConnection();
}
