using SistemaComercial.Dominio.Ventas;
using SistemaComercial.Dominio.Ventas.Repository;
using Microsoft.EntityFrameworkCore;

namespace SistemaComercial.Infrastructure.Repositories;

internal sealed class VentaRepository : Repository<Venta>, IVentaRepository
{
    public VentaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Venta?> GetBySerieNumeroAsync(string serie, int numero, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Ventas
            .Include(x => x.Alumno)
            .Include(x => x.Detalles)
                .ThenInclude(x => x.Curso)
            .FirstOrDefaultAsync(x => x.Serie == serie.ToUpper() && x.Numero == numero, cancellationToken);
    }

    public async Task<List<Venta>> ListAsync(DateTime? fechaInicio, DateTime? fechaFin, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Ventas
            .Include(x => x.Alumno)
            .AsQueryable();

        if (fechaInicio.HasValue)
        {
            var inicio = DateTime.SpecifyKind(fechaInicio.Value, DateTimeKind.Utc);
            query = query.Where(x => x.Fecha >= inicio);
        }

        if (fechaFin.HasValue)
        {
            var fin = DateTime.SpecifyKind(fechaFin.Value, DateTimeKind.Utc);
            query = query.Where(x => x.Fecha <= fin);
        }

        return await query
            .OrderByDescending(x => x.Fecha)
            .ThenByDescending(x => x.Numero)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetNextNumeroBySerieAsync(string serie, CancellationToken cancellationToken = default)
    {
        var maxNumero = await _dbContext.Ventas
            .Where(x => x.Serie == serie.ToUpper())
            .Select(x => (int?)x.Numero)
            .MaxAsync(cancellationToken);

        return (maxNumero ?? 0) + 1;
    }
}
