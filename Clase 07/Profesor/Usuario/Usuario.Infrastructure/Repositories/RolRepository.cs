using Microsoft.EntityFrameworkCore;
using Usuario.Dominio.Roles;

namespace Usuario.Infrastructure.Repositories;

internal sealed class RolRepository : Repository<Rol>, IRolRepository
{
    public RolRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Rol?> GetByNombreAsync(string nombre, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Rol>().FirstOrDefaultAsync(r => r.NombreRol == nombre, cancellationToken);
    }
}
