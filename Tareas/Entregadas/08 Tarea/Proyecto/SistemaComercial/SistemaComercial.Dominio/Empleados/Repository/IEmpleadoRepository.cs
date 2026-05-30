namespace SistemaComercial.Dominio.Empleados.Repository;

public interface IEmpleadoRepository
{
    void Add(Empleado empleado);

    void Update(Empleado empleado);

    Task<bool> ExistsAnyAsync(CancellationToken cancellationToken = default);

    Task<Empleado?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Empleado?> GetByCorreoEmpresarialAsync(string correoEmpresarial, CancellationToken cancellationToken = default);
}
