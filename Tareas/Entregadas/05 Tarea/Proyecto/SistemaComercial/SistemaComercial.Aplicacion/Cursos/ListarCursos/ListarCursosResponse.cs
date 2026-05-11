namespace SistemaComercial.Aplicacion.Cursos.ListarCursos;

public sealed record ListarCursosResponse(
    Guid Id,
    string Nombre,
    int CantidadHoras,
    decimal Precio);
