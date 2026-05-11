using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Alumnos.CrearAlumno;

public sealed record CrearAlumnoCommand(
    string Nombres,
    string Apellidos,
    string Direccion,
    string Ciudad) : ICommand<CrearAlumnoResponse>;
