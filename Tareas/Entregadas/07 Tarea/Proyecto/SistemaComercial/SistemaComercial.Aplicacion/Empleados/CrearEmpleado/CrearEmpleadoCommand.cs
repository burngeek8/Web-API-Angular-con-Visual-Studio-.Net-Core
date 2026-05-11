using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Shared.Enum;

namespace SistemaComercial.Aplicacion.Empleados.CrearEmpleado;

public sealed record CrearEmpleadoCommand
(
    string Nombres,
    string ApellidoPaterno,
    string? ApellidoMaterno,
    string NumeroDocumento,
    TipoDocumento TipoDocumento,
    string CorreoEmpresarial,
    decimal SalarioMonto,
    string SalarioMoneda,
    DateTime FechaIngreso,
    Guid CargoId
) : ICommand<CrearEmpleadoResponse>;
