namespace Empleado.Aplicacion.Empleados.ListarEmpleados;

public record ListarEmpleadosResponse
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
