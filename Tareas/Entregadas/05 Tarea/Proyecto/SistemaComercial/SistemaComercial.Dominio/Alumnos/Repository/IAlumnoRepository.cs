namespace SistemaComercial.Dominio.Alumnos.Repository;

public interface IAlumnoRepository
{
    Task<Alumno?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Alumno>> ListAsync(CancellationToken cancellationToken = default);
    void Add(Alumno alumno);
}
