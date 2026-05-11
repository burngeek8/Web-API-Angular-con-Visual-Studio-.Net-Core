using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Ventas.Repository;

namespace SistemaComercial.Aplicacion.Ventas.ListarVentas;

internal sealed class ListarVentasQueryHandler : IQueryHandler<ListarVentasQuery, List<ListarVentasResponse>>
{
    private readonly IVentaRepository _ventaRepository;

    public ListarVentasQueryHandler(IVentaRepository ventaRepository)
    {
        _ventaRepository = ventaRepository;
    }

    public async Task<List<ListarVentasResponse>> Handle(ListarVentasQuery request, CancellationToken cancellationToken)
    {
        var ventas = await _ventaRepository.ListAsync(request.FechaInicio, request.FechaFin, cancellationToken);
        return ventas
            .Select(x => new ListarVentasResponse(
                x.Id,
                x.Serie,
                x.Numero,
                $"{x.Serie}-{x.Numero:D8}",
                x.AlumnoId,
                $"{x.Alumno?.Nombres} {x.Alumno?.Apellidos}".Trim(),
                x.Fecha,
                x.Total))
            .ToList();
    }
}
