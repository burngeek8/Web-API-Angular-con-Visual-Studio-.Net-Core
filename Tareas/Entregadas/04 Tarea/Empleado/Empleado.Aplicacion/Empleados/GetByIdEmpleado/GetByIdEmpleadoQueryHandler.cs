using Dapper;
using Empleado.Aplicacion.Abstractions.Data;
using Empleado.Aplicacion.Abstractions.Messaging;

namespace Empleado.Aplicacion.Empleados.GetByIdEmpleado;

internal sealed class GetByIdEmpleadoQueryHandler : IQueryHandler<GetByIdEmpleadoQuery, GetByIdEmpleadoResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetByIdEmpleadoQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<GetByIdEmpleadoResponse> Handle(GetByIdEmpleadoQuery request, CancellationToken cancellationToken)
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
            WHERE e.id = @IdEmpleado
            """;

        var result = await connection.QueryFirstOrDefaultAsync<GetByIdEmpleadoResponse>(
            sql, new { IdEmpleado = request.Id });

        return result is not null
            ? result
            : throw new Exception($"No se encontro el empleado con ID: {request.Id}");
    }
}
