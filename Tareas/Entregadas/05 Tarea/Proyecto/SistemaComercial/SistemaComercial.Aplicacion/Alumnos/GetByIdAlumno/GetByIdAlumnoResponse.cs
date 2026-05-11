namespace SistemaComercial.Aplicacion.Alumnos.GetByIdAlumno;

public sealed record GetByIdAlumnoResponse(
    Guid Id,
    string Nombres,
    string Apellidos,
    string Direccion,
    string Ciudad);
