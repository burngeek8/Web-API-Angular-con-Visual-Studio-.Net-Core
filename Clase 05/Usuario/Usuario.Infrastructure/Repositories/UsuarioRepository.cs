using Usuario.Dominio.Usuarios.Repository;

namespace Usuario.Infrastructure.Repositories;

internal sealed class UsuarioRepository : Repository<Dominio.Usuarios.Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
