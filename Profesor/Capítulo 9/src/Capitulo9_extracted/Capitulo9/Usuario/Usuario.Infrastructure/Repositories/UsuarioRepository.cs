using Microsoft.EntityFrameworkCore;
using Usuario.Dominio.Usuarios.ObjectValue;
using Usuario.Dominio.Usuarios.Repository;

namespace Usuario.Infrastructure.Repositories;

internal sealed class UsuarioRepository : Repository<Dominio.Usuarios.Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Dominio.Usuarios.Usuario?> GetByUserNameAsync(string nombreUsuario, CancellationToken cancellationToken = default)
    {
       return await _dbContext.Set<Dominio.Usuarios.Usuario>()
            .Include(u => u.Rol)
            .FirstOrDefaultAsync(u => u.NombreUsuario == NombreUsuario.Create(nombreUsuario), cancellationToken);
    }
}
