using Empleado.Dominio.Abstractions;

namespace Empleado.Dominio.Cargos;

public class Cargo : Entity
{
    public string Nombre { get; private set; }

    private Cargo()
    {
        Nombre = string.Empty;
    }

    private Cargo(Guid id, string nombre) : base(id)
    {
        Nombre = nombre;
    }

    public static Cargo Create(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del cargo no puede estar vacío.");

        return new Cargo(Guid.NewGuid(), nombre);
    }
}
