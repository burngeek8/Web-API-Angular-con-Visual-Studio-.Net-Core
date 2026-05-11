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
                e.Id,
                e.Nombres,
                e.ApellidoPaterno,
                e.ApellidoMaterno,
                e.NumeroDocumento,
                e.TipoDocumento,
                e.CorreoEmpresarial,
                e.SalarioMonto,
                e.SalarioMoneda,
                e.CodigoEmpleado,
                e.FechaIngreso,
                e.Estado,
                c.Nombre AS NombreCargo
            FROM empleados e
            INNER JOIN cargos c 
            ON e.cargo_id = c.id
            WHERE e.id = @IdEmpleado
            """;

        var result = await connection.QueryFirstOrDefaultAsync<GetByIdEmpleadoResponse>(
            sql, new { IdEmpleado = request.Id });

        return result is not null
            ? result
            : throw new Exception($"No se encontró el empleado con ID: {request.Id}");
    }
}
