using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Alumnos.GetByIdAlumno;

public sealed record GetByIdAlumnoQuery(Guid Id) : IQuery<GetByIdAlumnoResponse>;
