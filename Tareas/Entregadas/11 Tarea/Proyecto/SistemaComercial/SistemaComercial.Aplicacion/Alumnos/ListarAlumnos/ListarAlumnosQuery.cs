using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Alumnos.ListarAlumnos;

public sealed record ListarAlumnosQuery() : IQuery<List<ListarAlumnosResponse>>;
