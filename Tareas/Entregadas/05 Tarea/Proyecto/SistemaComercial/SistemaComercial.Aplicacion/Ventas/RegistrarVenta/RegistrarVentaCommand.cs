using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Ventas.RegistrarVenta;

public sealed record RegistrarVentaCommand(
    string Serie,
    Guid AlumnoId,
    DateTime Fecha,
    List<RegistrarDetalleVentaRequest> Detalles) : ICommand<RegistrarVentaResponse>;
