namespace SistemaComercial.Aplicacion.Ventas.ListarVentas;

public sealed record ListarVentasResponse(
    Guid Id,
    string Serie,
    int Numero,
    string CodigoVenta,
    Guid AlumnoId,
    string Alumno,
    DateTime Fecha,
    decimal Total);
