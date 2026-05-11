namespace SistemaComercial.Aplicacion.Ventas.GetVentaBySerieNumero;

public sealed record GetVentaBySerieNumeroResponse(
    Guid Id,
    string Serie,
    int Numero,
    string CodigoVenta,
    Guid AlumnoId,
    string Alumno,
    DateTime Fecha,
    decimal Total,
    List<GetVentaBySerieNumeroDetalleResponse> Detalles);

public sealed record GetVentaBySerieNumeroDetalleResponse(
    Guid IdDetalleVenta,
    Guid CursoId,
    string Curso,
    int Cantidad,
    decimal Precio,
    decimal Total);
