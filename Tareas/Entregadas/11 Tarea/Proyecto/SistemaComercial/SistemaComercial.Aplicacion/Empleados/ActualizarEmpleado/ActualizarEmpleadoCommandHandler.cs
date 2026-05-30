using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Abstractions;
using SistemaComercial.Dominio.Cargos;
using SistemaComercial.Dominio.Empleados.ObjectValue;
using SistemaComercial.Dominio.Empleados.Repository;
using SistemaComercial.Dominio.Empleados.Services;

namespace SistemaComercial.Aplicacion.Empleados.ActualizarEmpleado;

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

        var cargo = await _cargoRepository.GetByIdAsync(request.CargoId, cancellationToken);
        if (cargo is null)
            throw new Exception($"El cargo con ID '{request.CargoId}' no existe.");

        var fechaIngresoUtc = request.FechaIngreso.Kind switch
        {
            DateTimeKind.Utc => request.FechaIngreso,
            DateTimeKind.Local => request.FechaIngreso.ToUniversalTime(),
            _ => DateTime.SpecifyKind(request.FechaIngreso, DateTimeKind.Utc)
        };

        var nombreCompleto = NombreCompleto.Create(request.Nombres, request.ApellidoPaterno, request.ApellidoMaterno);
        var numeroDocumento = NumeroDocumento.Create(request.NumeroDocumento, request.TipoDocumento);
        var correo = CorreoEmpresarial.Crear(request.CorreoEmpresarial);
        var salario = Salario.Create(request.SalarioMonto, request.SalarioMoneda);

        empleado.Actualizar(
            nombreCompleto,
            numeroDocumento,
            correo,
            salario,
            fechaIngresoUtc,
            request.Estado,
            request.CargoId,
            _codigoEmpleadoServices);

        _empleadoRepository.Update(empleado);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
