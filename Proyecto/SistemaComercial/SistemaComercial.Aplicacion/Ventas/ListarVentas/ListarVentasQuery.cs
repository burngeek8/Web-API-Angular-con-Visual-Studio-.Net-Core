using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Ventas.ListarVentas;

public sealed record ListarVentasQuery(
    DateTime? FechaInicio,
    DateTime? FechaFin) : IQuery<List<ListarVentasResponse>>;
