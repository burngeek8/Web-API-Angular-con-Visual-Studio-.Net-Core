namespace SistemaComercial.Aplicacion.Cursos.GetByIdCurso;

public sealed record GetByIdCursoResponse(
    Guid Id,
    string Nombre,
    int CantidadHoras,
    decimal Precio);
