namespace Usuario.Api.Controllers;

public record CreateUsuarioRequest
(
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
    string NombreRol
);
