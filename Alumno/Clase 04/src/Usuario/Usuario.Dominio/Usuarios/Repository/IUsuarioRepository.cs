namespace Usuario.Dominio.Usuarios.Repository;

public interface IUsuarioRepository
{
    void Add(Usuario usuario);

    Task<Usuario?> GetByIdAsync(Guid id,CancellationToken cancellationToken = default);
}
