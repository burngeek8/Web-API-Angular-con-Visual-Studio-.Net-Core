namespace SistemaComercial.Aplicacion.Ventas.RegistrarVenta;

public sealed record RegistrarVentaResponse(
    Guid Id,
    string Serie,
    int Numero,
    string CodigoVenta,
    decimal Total);
