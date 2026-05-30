namespace SistemaComercial.Aplicacion.Alumnos.ListarAlumnos;

public sealed record ListarAlumnosResponse(
    Guid Id,
    string Nombres,
    string Apellidos,
    string Direccion,
    string Ciudad);
