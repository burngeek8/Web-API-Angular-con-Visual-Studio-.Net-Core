using Dapper;
using Usuario.Aplication.Abstractions.Data;
using Usuario.Aplication.Abstractions.Messaging;

namespace Usuario.Aplication.Usuarios.GetByIdUsuario;

internal sealed class GetByIdUsuarioQueryHandler : IQueryHandler<GetByIdUsuarioQuery, GetByIdUsuarioResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetByIdUsuarioQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<GetByIdUsuarioResponse> Handle(GetByIdUsuarioQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var sql = """
            SELECT 
                u.Id,
                u.NombresPersona,
                u.ApellidoPaterno,
                u.ApellidoMaterno,
                u.Password,
                u.FechaNacimiento,
                u.CorreoElectronico,
                u.Pais,
                u.Departamento,
                u.Provincia,
                u.Distrito,
                u.Calle,
                r.Nombre AS NombreRol,
                u.FechaUltimoCambio,
                u.Estado 
                From usuarios u INNER JOIN  roles r 
                ON u.rol_id = r.id
                WHERE u.id = @IdUsuario
            """;

        var usuarioResult = await connection.QueryFirstOrDefaultAsync<GetByIdUsuarioResponse>(
           sql, new { IdUsuario = request.Id });

        return usuarioResult is not null ? usuarioResult : throw new Exception($"No se encontró el usuario con ID: {request.Id}");
    }
}
