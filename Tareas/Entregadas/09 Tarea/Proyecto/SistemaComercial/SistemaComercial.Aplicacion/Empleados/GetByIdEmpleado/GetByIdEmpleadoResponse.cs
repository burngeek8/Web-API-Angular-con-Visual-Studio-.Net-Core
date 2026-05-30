namespace SistemaComercial.Aplicacion.Empleados.GetByIdEmpleado;

public record GetByIdEmpleadoResponse
(
    Guid Id,
    string Nombres,
    string ApellidoPaterno,
    string? ApellidoMaterno,
    string NumeroDocumento,
    string TipoDocumento,
    string CorreoEmpresarial,
    decimal SalarioMonto,
    string SalarioMoneda,
    string CodigoEmpleado,
    DateTime FechaIngreso,
    string Estado,
    string NombreCargo
);
