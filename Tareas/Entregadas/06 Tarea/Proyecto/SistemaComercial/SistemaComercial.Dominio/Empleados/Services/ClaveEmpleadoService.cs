namespace SistemaComercial.Dominio.Empleados.Services;

public class ClaveEmpleadoService
{
    public string GenerarTemporal()
    {
        return $"Emp{Guid.NewGuid():N}"[..14];
    }
}
