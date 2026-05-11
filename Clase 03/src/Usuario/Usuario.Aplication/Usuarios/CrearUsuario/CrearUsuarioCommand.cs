using Usuario.Aplication.Abstractions.Messaging;

namespace Usuario.Aplication.Usuarios.CrearUsuario;

public sealed record CrearUsuarioCommand
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
): ICommand<Guid>;