using Empleado.Dominio.Empleados.Repository;

namespace Empleado.Infrastructure.Repositories;

internal sealed class EmpleadoRepository : Repository<Dominio.Empleados.Empleado>, IEmpleadoRepository
{
    public EmpleadoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
