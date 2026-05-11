namespace Usuario.Dominio.Roles;

public interface IRolRepository
{
    Task<Rol?> GetByNombreAsync(string  nombre, CancellationToken cancellationToken  = default);
}
