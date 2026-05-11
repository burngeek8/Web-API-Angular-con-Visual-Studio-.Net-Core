using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Ventas.Repository;

namespace SistemaComercial.Aplicacion.Ventas.GetVentaBySerieNumero;

internal sealed class GetVentaBySerieNumeroQueryHandler : IQueryHandler<GetVentaBySerieNumeroQuery, GetVentaBySerieNumeroResponse>
{
    private readonly IVentaRepository _ventaRepository;

    public GetVentaBySerieNumeroQueryHandler(IVentaRepository ventaRepository)
    {
        _ventaRepository = ventaRepository;
    }

    public async Task<GetVentaBySerieNumeroResponse> Handle(GetVentaBySerieNumeroQuery request, CancellationToken cancellationToken)
    {
        var venta = await _ventaRepository.GetBySerieNumeroAsync(request.Serie, request.Numero, cancellationToken)
            ?? throw new KeyNotFoundException($"No existe una venta con codigo '{request.Serie}-{request.Numero:D8}'.");

        return new GetVentaBySerieNumeroResponse(
            venta.Id,
            venta.Serie,
            venta.Numero,
            $"{venta.Serie}-{venta.Numero:D8}",
            venta.AlumnoId,
            $"{venta.Alumno?.Nombres} {venta.Alumno?.Apellidos}".Trim(),
            venta.Fecha,
            venta.Total,
            venta.Detalles
                .Select(x => new GetVentaBySerieNumeroDetalleResponse(
                    x.Id,
                    x.CursoId,
                    x.Curso?.Nombre ?? string.Empty,
                    x.Cantidad,
                    x.Precio,
                    x.Total))
                .ToList());
    }
}
