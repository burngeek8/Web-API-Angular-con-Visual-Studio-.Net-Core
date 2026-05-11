namespace SistemaComercial.Dominio.Ventas.Repository;

public interface IVentaRepository
{
    Task<Venta?> GetBySerieNumeroAsync(string serie, int numero, CancellationToken cancellationToken = default);
    Task<List<Venta>> ListAsync(DateTime? fechaInicio, DateTime? fechaFin, CancellationToken cancellationToken = default);
    Task<int> GetNextNumeroBySerieAsync(string serie, CancellationToken cancellationToken = default);
    void Add(Venta venta);
}
