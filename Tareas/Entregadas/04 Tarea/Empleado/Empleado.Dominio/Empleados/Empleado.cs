using Empleado.Dominio.Abstractions;
using Empleado.Dominio.Cargos;
using Empleado.Dominio.Empleados.ObjectValue;
using Empleado.Dominio.Empleados.Services;
using Empleado.Dominio.Shared.Enum;

namespace Empleado.Dominio.Empleados;

public class Empleado : Entity
{
    private Empleado()
    {
        NombreCompleto = null!;
        NumeroDocumento = null!;
        CorreoEmpresarial = null!;
        Salario = null!;
        CodigoEmpleado = null!;
    }

    private Empleado(
        Guid id,
        NombreCompleto nombreCompleto,
        NumeroDocumento numeroDocumento,
        CorreoEmpresarial correoEmpresarial,
        Salario salario,
        CodigoEmpleado codigoEmpleado,
        DateTime fechaIngreso,
        EstadoEmpleado estado,
        Guid cargoId) : base(id)
    {
        NombreCompleto = nombreCompleto;
        NumeroDocumento = numeroDocumento;
        CorreoEmpresarial = correoEmpresarial;
        Salario = salario;
        CodigoEmpleado = codigoEmpleado;
        FechaIngreso = fechaIngreso;
        Estado = estado;
        CargoId = cargoId;
    }

    public NombreCompleto NombreCompleto { get; private set; }
    public NumeroDocumento NumeroDocumento { get; private set; }
    public CorreoEmpresarial CorreoEmpresarial { get; private set; }
    public Salario Salario { get; private set; }
    public CodigoEmpleado CodigoEmpleado { get; private set; }
    public DateTime FechaIngreso { get; private set; }
    public EstadoEmpleado Estado { get; private set; }
    public Cargo? Cargo { get; private set; }
    public Guid CargoId { get; private set; }

    public static Empleado Create(
        NombreCompleto nombreCompleto,
        NumeroDocumento numeroDocumento,
        CorreoEmpresarial correoEmpresarial,
        Salario salario,
        DateTime fechaIngreso,
        Guid cargoId,
        CodigoEmpleadoServices codigoEmpleadoServices)
    {
        var codigoGenerado = codigoEmpleadoServices.GenerarCodigo(
            nombreCompleto.Nombres,
            nombreCompleto.ApellidoPaterno,
            fechaIngreso);

        return new Empleado(
            Guid.NewGuid(),
            nombreCompleto,
            numeroDocumento,
            correoEmpresarial,
            salario,
            codigoGenerado,
            fechaIngreso,
            EstadoEmpleado.Activo,
            cargoId);
    }

    public void Actualizar(
        NombreCompleto nombreCompleto,
        NumeroDocumento numeroDocumento,
        CorreoEmpresarial correoEmpresarial,
        Salario salario,
        DateTime fechaIngreso,
        EstadoEmpleado estado,
        Guid cargoId,
        CodigoEmpleadoServices codigoEmpleadoServices)
    {
        NombreCompleto = nombreCompleto;
        NumeroDocumento = numeroDocumento;
        CorreoEmpresarial = correoEmpresarial;
        Salario = salario;
        FechaIngreso = fechaIngreso;
        Estado = estado;
        CargoId = cargoId;
        CodigoEmpleado = codigoEmpleadoServices.GenerarCodigo(
            nombreCompleto.Nombres,
            nombreCompleto.ApellidoPaterno,
            fechaIngreso);
    }
}
