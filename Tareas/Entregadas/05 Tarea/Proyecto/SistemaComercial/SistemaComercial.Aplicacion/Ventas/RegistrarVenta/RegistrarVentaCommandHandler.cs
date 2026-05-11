using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Abstractions;
using SistemaComercial.Dominio.Alumnos.Repository;
using SistemaComercial.Dominio.Cursos.Repository;
using SistemaComercial.Dominio.Ventas;
using SistemaComercial.Dominio.Ventas.Repository;

namespace SistemaComercial.Aplicacion.Ventas.RegistrarVenta;

internal sealed class RegistrarVentaCommandHandler : ICommandHandler<RegistrarVentaCommand, RegistrarVentaResponse>
{
    private readonly IAlumnoRepository _alumnoRepository;
    private readonly ICursoRepository _cursoRepository;
    private readonly IVentaRepository _ventaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegistrarVentaCommandHandler(
        IAlumnoRepository alumnoRepository,
        ICursoRepository cursoRepository,
        IVentaRepository ventaRepository,
        IUnitOfWork unitOfWork)
    {
        _alumnoRepository = alumnoRepository;
        _cursoRepository = cursoRepository;
        _ventaRepository = ventaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegistrarVentaResponse> Handle(RegistrarVentaCommand request, CancellationToken cancellationToken)
    {
        var alumno = await _alumnoRepository.GetByIdAsync(request.AlumnoId, cancellationToken);
        if (alumno is null)
            throw new KeyNotFoundException($"No existe un alumno con id '{request.AlumnoId}'.");

        if (request.Detalles is null || request.Detalles.Count == 0)
            throw new ArgumentException("La venta debe incluir al menos un detalle.");

        var serie = string.IsNullOrWhiteSpace(request.Serie) ? "NV01" : request.Serie.Trim().ToUpperInvariant();
        var numero = await _ventaRepository.GetNextNumeroBySerieAsync(serie, cancellationToken);

        var detalles = new List<DetalleVenta>();
        foreach (var detalleRequest in request.Detalles)
        {
            var curso = await _cursoRepository.GetByIdAsync(detalleRequest.CursoId, cancellationToken);
            if (curso is null)
                throw new KeyNotFoundException($"No existe un curso con id '{detalleRequest.CursoId}'.");

            detalles.Add(DetalleVenta.Create(curso.Id, detalleRequest.Cantidad, curso.Precio));
        }

        var fecha = request.Fecha.Kind == DateTimeKind.Unspecified
            ? DateTime.SpecifyKind(request.Fecha, DateTimeKind.Utc)
            : request.Fecha.ToUniversalTime();

        var venta = Venta.Create(request.AlumnoId, fecha, serie, numero, detalles);
        _ventaRepository.Add(venta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new RegistrarVentaResponse(
            venta.Id,
            venta.Serie,
            venta.Numero,
            $"{venta.Serie}-{venta.Numero:D8}",
            venta.Total);
    }
}
