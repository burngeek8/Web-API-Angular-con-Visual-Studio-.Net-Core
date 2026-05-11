namespace SistemaComercial.Dominio.Cargos;

public interface ICargoRepository
{
    void Add(Cargo cargo);
    Task<List<Cargo>> ListAsync(CancellationToken cancellationToken = default);
    Task<bool> ExistsAnyAsync(CancellationToken cancellationToken = default);
    Task<Cargo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Cargo?> GetByNombreAsync(string nombre, CancellationToken cancellationToken = default);
}
