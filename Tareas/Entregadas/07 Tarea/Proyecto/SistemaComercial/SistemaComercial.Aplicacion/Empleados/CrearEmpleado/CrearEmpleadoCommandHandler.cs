using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Abstractions;
using SistemaComercial.Dominio.Cargos;
using SistemaComercial.Dominio.Empleados.ObjectValue;
using SistemaComercial.Dominio.Empleados.Repository;
using SistemaComercial.Dominio.Empleados.Services;

namespace SistemaComercial.Aplicacion.Empleados.CrearEmpleado;

internal sealed class CrearEmpleadoCommandHandler : ICommandHandler<CrearEmpleadoCommand, CrearEmpleadoResponse>
{
    private readonly ICargoRepository _cargoRepository;
    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly CodigoEmpleadoServices _codigoEmpleadoServices;
    private readonly ClaveEmpleadoService _claveEmpleadoService;
    private readonly IUnitOfWork _unitOfWork;

    public CrearEmpleadoCommandHandler(
        ICargoRepository cargoRepository,
        IEmpleadoRepository empleadoRepository,
        CodigoEmpleadoServices codigoEmpleadoServices,
        ClaveEmpleadoService claveEmpleadoService,
        IUnitOfWork unitOfWork)
    {
        _cargoRepository = cargoRepository;
        _empleadoRepository = empleadoRepository;
        _codigoEmpleadoServices = codigoEmpleadoServices;
        _claveEmpleadoService = claveEmpleadoService;
        _unitOfWork = unitOfWork;
    }

    public async Task<CrearEmpleadoResponse> Handle(CrearEmpleadoCommand request, CancellationToken cancellationToken)
    {
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
        var claveTemporal = _claveEmpleadoService.GenerarTemporal();

        var empleado = Dominio.Empleados.Empleado.Create(
            nombreCompleto,
            numeroDocumento,
            correo,
            salario,
            fechaIngresoUtc,
            request.CargoId,
            _codigoEmpleadoServices,
            claveTemporal
        );

        _empleadoRepository.Add(empleado);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new CrearEmpleadoResponse(empleado.Id, claveTemporal);
    }
}
