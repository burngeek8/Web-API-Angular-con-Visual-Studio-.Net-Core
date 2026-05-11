using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Empleados.GetByIdEmpleado;

public sealed record GetByIdEmpleadoQuery(Guid Id) : IQuery<GetByIdEmpleadoResponse>;
