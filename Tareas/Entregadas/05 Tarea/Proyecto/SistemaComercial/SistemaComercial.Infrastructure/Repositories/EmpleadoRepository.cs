using SistemaComercial.Dominio.Empleados.Repository;
using SistemaComercial.Dominio.Empleados.ObjectValue;
using Microsoft.EntityFrameworkCore;

namespace SistemaComercial.Infrastructure.Repositories;

internal sealed class EmpleadoRepository : Repository<Dominio.Empleados.Empleado>, IEmpleadoRepository
{
    public EmpleadoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistsAnyAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Dominio.Empleados.Empleado>().AnyAsync(cancellationToken);
    }

    public new void Update(Dominio.Empleados.Empleado empleado)
    {
        base.Update(empleado);
    }

    public async Task<Dominio.Empleados.Empleado?> GetByCorreoEmpresarialAsync(string correoEmpresarial, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Dominio.Empleados.Empleado>()
            .Include(e => e.Cargo)
            .FirstOrDefaultAsync(e => e.CorreoEmpresarial == CorreoEmpresarial.Crear(correoEmpresarial), cancellationToken);
    }
}
