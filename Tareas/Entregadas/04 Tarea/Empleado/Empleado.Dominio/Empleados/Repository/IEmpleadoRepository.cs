namespace Empleado.Dominio.Empleados.Repository;

public interface IEmpleadoRepository
{
    void Add(Empleado empleado);

    void Update(Empleado empleado);

    Task<Empleado?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
