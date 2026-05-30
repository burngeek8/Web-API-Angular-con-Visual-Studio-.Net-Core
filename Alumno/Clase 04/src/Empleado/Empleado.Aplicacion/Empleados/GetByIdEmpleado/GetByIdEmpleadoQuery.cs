using Empleado.Aplicacion.Abstractions.Messaging;

namespace Empleado.Aplicacion.Empleados.GetByIdEmpleado;

public sealed record GetByIdEmpleadoQuery(Guid Id) : IQuery<GetByIdEmpleadoResponse>;
