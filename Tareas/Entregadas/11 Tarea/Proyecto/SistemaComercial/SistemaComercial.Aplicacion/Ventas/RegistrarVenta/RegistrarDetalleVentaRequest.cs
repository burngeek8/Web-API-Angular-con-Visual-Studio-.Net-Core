namespace SistemaComercial.Aplicacion.Ventas.RegistrarVenta;

public sealed record RegistrarDetalleVentaRequest(
    Guid CursoId,
    int Cantidad);
