using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Cursos.CrearCurso;

public sealed record CrearCursoCommand(
    string Nombre,
    int CantidadHoras,
    decimal Precio) : ICommand<CrearCursoResponse>;
