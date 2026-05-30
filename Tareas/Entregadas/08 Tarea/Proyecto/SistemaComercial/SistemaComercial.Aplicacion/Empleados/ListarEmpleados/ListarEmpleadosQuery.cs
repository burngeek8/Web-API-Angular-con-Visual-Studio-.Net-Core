using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Empleados.ListarEmpleados;

public sealed record ListarEmpleadosQuery : IQuery<List<ListarEmpleadosResponse>>;
