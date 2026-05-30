using SistemaComercial.Dominio.Cursos;
using SistemaComercial.Dominio.Cursos.Repository;
using Microsoft.EntityFrameworkCore;

namespace SistemaComercial.Infrastructure.Repositories;

internal sealed class CursoRepository : Repository<Curso>, ICursoRepository
{
    public CursoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Curso>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Cursos
            .OrderBy(x => x.Nombre)
            .ToListAsync(cancellationToken);
    }
}
