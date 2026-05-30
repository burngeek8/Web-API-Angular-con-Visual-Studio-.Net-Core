namespace SistemaComercial.Dominio.Cursos.Repository;

public interface ICursoRepository
{
    Task<Curso?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Curso>> ListAsync(CancellationToken cancellationToken = default);
    void Add(Curso curso);
}
