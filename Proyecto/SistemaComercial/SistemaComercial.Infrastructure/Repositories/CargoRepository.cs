using SistemaComercial.Dominio.Cargos;
using Microsoft.EntityFrameworkCore;

namespace SistemaComercial.Infrastructure.Repositories;

internal sealed class CargoRepository : Repository<Cargo>, ICargoRepository
{
    public CargoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public new void Add(Cargo cargo)
    {
        base.Add(cargo);
    }

    public async Task<List<Cargo>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Cargo>()
            .OrderBy(c => c.Nombre)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> ExistsAnyAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Cargo>().AnyAsync(cancellationToken);
    }

    public async Task<Cargo?> GetByNombreAsync(string nombre, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Cargo>().FirstOrDefaultAsync(c => c.Nombre == nombre, cancellationToken);
    }
}
