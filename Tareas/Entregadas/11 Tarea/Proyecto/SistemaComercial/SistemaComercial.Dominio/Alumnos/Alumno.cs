using SistemaComercial.Dominio.Abstractions;

namespace SistemaComercial.Dominio.Alumnos;

public class Alumno : Entity
{
    public string Nombres { get; private set; }
    public string Apellidos { get; private set; }
    public string Direccion { get; private set; }
    public string Ciudad { get; private set; }

    private Alumno()
    {
        Nombres = string.Empty;
        Apellidos = string.Empty;
        Direccion = string.Empty;
        Ciudad = string.Empty;
    }

    private Alumno(Guid id, string nombres, string apellidos, string direccion, string ciudad) : base(id)
    {
        Nombres = nombres;
        Apellidos = apellidos;
        Direccion = direccion;
        Ciudad = ciudad;
    }

    public static Alumno Create(string nombres, string apellidos, string direccion, string ciudad)
    {
        if (string.IsNullOrWhiteSpace(nombres))
            throw new ArgumentException("Los nombres del alumno son obligatorios.");

        if (string.IsNullOrWhiteSpace(apellidos))
            throw new ArgumentException("Los apellidos del alumno son obligatorios.");

        if (string.IsNullOrWhiteSpace(direccion))
            throw new ArgumentException("La direccion del alumno es obligatoria.");

        if (string.IsNullOrWhiteSpace(ciudad))
            throw new ArgumentException("La ciudad del alumno es obligatoria.");

        return new Alumno(Guid.NewGuid(), nombres.Trim(), apellidos.Trim(), direccion.Trim(), ciudad.Trim());
    }
}
