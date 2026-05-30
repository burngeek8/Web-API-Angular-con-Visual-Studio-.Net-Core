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
                u.id as Id,
                u.nombres_persona as NombresPersona,
                u.apellido_paterno as ApellidoPaterno,
                u.apellido_materno as ApellidoMaterno,
                u.password as Password,
                u.fecha_nacimiento as FechaNacimiento,
                u.correo_electronico as CorreoElectronico,
                u.direccion_pais as Pais,
                u.direccion_departamento as Departamento,
                u.direccion_provincia as Provincia,
                u.direccion_distrito as Distrito,
                u.direccion_calle as Calle,
                r.nombre_rol AS NombreRol,
                u.fecha_ultimo_cambio as FechaUltimoCambio,
                u.estado as Estado
                From usuarios u INNER JOIN  roles r 
                ON u.rol_id = r.id
                WHERE u.id = @IdUsuario
            """;

        var usuarioResult = await connection.QueryFirstOrDefaultAsync<GetByIdUsuarioResponse>(
           sql, new { IdUsuario = request.Id });

        return usuarioResult is not null ? usuarioResult : throw new Exception($"No se encontró el usuario con ID: {request.Id}");
    }
}
