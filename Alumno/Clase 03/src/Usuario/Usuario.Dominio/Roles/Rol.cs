using Usuario.Dominio.Abstractions;

namespace Usuario.Dominio.Roles;

public class Rol : Entity
{
    public Rol(Guid id, string? nombreRol, string? descripcion) : base(id)
    {
        NombreRol = nombreRol;
        Descripcion = descripcion;
    }

    public string? NombreRol { get; private set; }
    public string? Descripcion { get; private set; }
}
