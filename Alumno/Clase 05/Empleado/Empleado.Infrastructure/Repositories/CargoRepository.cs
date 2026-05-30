using Empleado.Dominio.Cargos;
using Microsoft.EntityFrameworkCore;

namespace Empleado.Infrastructure.Repositories;

internal sealed class CargoRepository : Repository<Cargo>, ICargoRepository
{
    public CargoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Cargo?> GetByNombreAsync(string nombre, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Cargo>().FirstOrDefaultAsync(c => c.Nombre == nombre, cancellationToken);
    }
}
