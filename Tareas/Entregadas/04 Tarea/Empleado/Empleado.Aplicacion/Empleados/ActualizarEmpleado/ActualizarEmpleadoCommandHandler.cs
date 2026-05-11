using Empleado.Aplicacion.Abstractions.Messaging;
using Empleado.Dominio.Abstractions;
using Empleado.Dominio.Cargos;
using Empleado.Dominio.Empleados.ObjectValue;
using Empleado.Dominio.Empleados.Repository;
using Empleado.Dominio.Empleados.Services;

namespace Empleado.Aplicacion.Empleados.ActualizarEmpleado;

internal sealed class ActualizarEmpleadoCommandHandler : ICommandHandler<ActualizarEmpleadoCommand>
{
    private readonly ICargoRepository _cargoRepository;
    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly CodigoEmpleadoServices _codigoEmpleadoServices;
    private readonly IUnitOfWork _unitOfWork;

    public ActualizarEmpleadoCommandHandler(
        ICargoRepository cargoRepository,
        IEmpleadoRepository empleadoRepository,
        CodigoEmpleadoServices codigoEmpleadoServices,
        IUnitOfWork unitOfWork)
    {
        _cargoRepository = cargoRepository;
        _empleadoRepository = empleadoRepository;
        _codigoEmpleadoServices = codigoEmpleadoServices;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ActualizarEmpleadoCommand request, CancellationToken cancellationToken)
    {
        var empleado = await _empleadoRepository.GetByIdAsync(request.Id, cancellationToken);
        if (empleado is null)
            throw new Exception($"No se encontro el empleado con ID: {request.Id}");

        var cargo = await _cargoRepository.GetByNombreAsync(request.NombreCargo, cancellationToken);
        if (cargo is null)
            throw new Exception($"El cargo '{request.NombreCargo}' no existe.");

        var nombreCompleto = NombreCompleto.Create(request.Nombres, request.ApellidoPaterno, request.ApellidoMaterno);
        var numeroDocumento = NumeroDocumento.Create(request.NumeroDocumento, request.TipoDocumento);
        var correo = CorreoEmpresarial.Crear(request.CorreoEmpresarial);
        var salario = Salario.Create(request.SalarioMonto, request.SalarioMoneda);

        empleado.Actualizar(
            nombreCompleto,
            numeroDocumento,
            correo,
            salario,
            request.FechaIngreso,
            request.Estado,
            cargo.Id,
            _codigoEmpleadoServices);

        _empleadoRepository.Update(empleado);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
