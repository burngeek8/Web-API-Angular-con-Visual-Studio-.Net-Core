using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Cursos.ListarCursos;

public sealed record ListarCursosQuery() : IQuery<List<ListarCursosResponse>>;
