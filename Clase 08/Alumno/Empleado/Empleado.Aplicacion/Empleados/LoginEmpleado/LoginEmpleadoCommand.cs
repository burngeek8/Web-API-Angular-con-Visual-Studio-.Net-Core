using Empleado.Aplicacion.Abstractions.Messaging;

namespace Empleado.Aplicacion.Empleados.LoginEmpleado;

public sealed record LoginEmpleadoCommand(
    string CorreoEmpresarial,
    string Clave
) : ICommand<LoginEmpleadoResponse>;
