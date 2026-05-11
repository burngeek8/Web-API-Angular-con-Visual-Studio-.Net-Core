using Dapper;
using Empleado.Aplicacion.Abstractions.Data;
using Empleado.Aplicacion.Abstractions.Messaging;

namespace Empleado.Aplicacion.Empleados.ListarEmpleados;

internal sealed class ListarEmpleadosQueryHandler : IQueryHandler<ListarEmpleadosQuery, List<ListarEmpleadosResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public ListarEmpleadosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<ListarEmpleadosResponse>> Handle(ListarEmpleadosQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var sql = """
            SELECT
                e.id,
                e.nombres,
                e.apellido_paterno AS ApellidoPaterno,
                e.apellido_materno AS ApellidoMaterno,
                e.numero_documento AS NumeroDocumento,
                e.tipo_documento AS TipoDocumento,
                e.correo_empresarial AS CorreoEmpresarial,
                e.salario_monto AS SalarioMonto,
                e.salario_moneda AS SalarioMoneda,
                e.codigo_empleado AS CodigoEmpleado,
                e.fecha_ingreso AS FechaIngreso,
                e.estado,
                c.nombre AS NombreCargo
            FROM empleados e
            INNER JOIN cargos c ON e.cargo_id = c.id
            ORDER BY e.apellido_paterno, e.apellido_materno, e.nombres
            """;

        var result = await connection.QueryAsync<ListarEmpleadosResponse>(sql);

        return result.ToList();
    }
}
