using System.Data.Common;

namespace Empleado.Aplicacion.Abstractions.Data;

internal interface ISqlConnectionFactory
{
    DbConnection CreateConnection();
}
