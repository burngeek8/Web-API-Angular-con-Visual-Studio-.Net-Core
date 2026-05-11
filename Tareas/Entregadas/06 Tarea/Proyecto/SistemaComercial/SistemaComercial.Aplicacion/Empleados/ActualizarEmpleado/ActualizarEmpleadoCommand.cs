using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Shared.Enum;

namespace SistemaComercial.Aplicacion.Empleados.ActualizarEmpleado;

public sealed record ActualizarEmpleadoCommand
(
    Guid Id,
    string Nombres,
    string ApellidoPaterno,
    string? ApellidoMaterno,
    string NumeroDocumento,
    TipoDocumento TipoDocumento,
    string CorreoEmpresarial,
    decimal SalarioMonto,
    string SalarioMoneda,
    DateTime FechaIngreso,
    EstadoEmpleado Estado,
    Guid CargoId
) : ICommand;
