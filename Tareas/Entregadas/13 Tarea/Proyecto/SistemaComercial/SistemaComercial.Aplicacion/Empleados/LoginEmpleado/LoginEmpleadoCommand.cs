using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Empleados.LoginEmpleado;

public sealed record LoginEmpleadoCommand(
    string CorreoEmpresarial,
    string Clave
) : ICommand<LoginEmpleadoResponse>;
