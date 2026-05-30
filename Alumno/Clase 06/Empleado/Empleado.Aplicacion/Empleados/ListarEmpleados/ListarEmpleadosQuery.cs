using Empleado.Aplicacion.Abstractions.Messaging;

namespace Empleado.Aplicacion.Empleados.ListarEmpleados;

public sealed record ListarEmpleadosQuery : IQuery<List<ListarEmpleadosResponse>>;
