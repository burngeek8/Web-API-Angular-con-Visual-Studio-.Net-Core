namespace Empleado.Dominio.Cargos;

public interface ICargoRepository
{
    Task<Cargo?> GetByNombreAsync(string nombre, CancellationToken cancellationToken = default);
}
