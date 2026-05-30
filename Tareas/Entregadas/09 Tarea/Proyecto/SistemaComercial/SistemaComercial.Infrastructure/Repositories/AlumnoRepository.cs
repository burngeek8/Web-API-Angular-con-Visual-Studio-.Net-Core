using SistemaComercial.Dominio.Alumnos;
using SistemaComercial.Dominio.Alumnos.Repository;
using Microsoft.EntityFrameworkCore;

namespace SistemaComercial.Infrastructure.Repositories;

internal sealed class AlumnoRepository : Repository<Alumno>, IAlumnoRepository
{
    public AlumnoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Alumno>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Alumnos
            .OrderBy(x => x.Apellidos)
            .ThenBy(x => x.Nombres)
            .ToListAsync(cancellationToken);
    }
}
