using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Cursos.GetByIdCurso;

public sealed record GetByIdCursoQuery(Guid Id) : IQuery<GetByIdCursoResponse>;
