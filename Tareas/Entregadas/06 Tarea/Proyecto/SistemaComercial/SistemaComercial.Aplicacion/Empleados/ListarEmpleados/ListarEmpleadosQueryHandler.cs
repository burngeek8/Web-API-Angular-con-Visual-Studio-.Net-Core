using Dapper;
using SistemaComercial.Aplicacion.Abstractions.Data;
using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Empleados.ListarEmpleados;

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
                e.nombre_completo_nombres AS Nombres,
                e.nombre_completo_apellido_paterno AS ApellidoPaterno,
                e.nombre_completo_apellido_materno AS ApellidoMaterno,
                e.numero_documento_valor AS NumeroDocumento,
                e.numero_documento_tipo AS TipoDocumento,
                e.correo_empresarial AS CorreoEmpresarial,
                e.salario_monto AS SalarioMonto,
                e.salario_moneda AS SalarioMoneda,
                e.codigo_empleado AS CodigoEmpleado,
                e.fecha_ingreso AS FechaIngreso,
                e.estado AS Estado,
                c.nombre AS NombreCargo
            FROM empleados e
            INNER JOIN cargos c ON e.cargo_id = c.id
            ORDER BY e.nombre_completo_apellido_paterno, e.nombre_completo_apellido_materno, e.nombre_completo_nombres
            """;

        var result = await connection.QueryAsync<ListarEmpleadosResponse>(sql);

        return result.ToList();
    }
}
