namespace Usuario.Aplication.Usuarios.GetByIdUsuario;

public record GetByIdUsuarioResponse
(
    Guid Id,
    string NombresPersona,
    string ApellidoPaterno,
    string? ApellidoMaterno,
    string? Password,
    DateTime FechaNacimiento,
    string? CorreoElectronico,
    string Pais,
    string Departamento,
    string Provincia,
    string Distrito,
    string Calle,
    string NombreRol,
    DateTime FechaUltimoCambio,
    string Estado
);