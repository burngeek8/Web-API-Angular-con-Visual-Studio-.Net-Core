using SistemaComercial.Dominio.Abstractions;

namespace SistemaComercial.Dominio.Cursos;

public class Curso : Entity
{
    public string Nombre { get; private set; }
    public int CantidadHoras { get; private set; }
    public decimal Precio { get; private set; }

    private Curso()
    {
        Nombre = string.Empty;
    }

    private Curso(Guid id, string nombre, int cantidadHoras, decimal precio) : base(id)
    {
        Nombre = nombre;
        CantidadHoras = cantidadHoras;
        Precio = precio;
    }

    public static Curso Create(string nombre, int cantidadHoras, decimal precio)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del curso es obligatorio.");

        if (cantidadHoras <= 0)
            throw new ArgumentException("La cantidad de horas debe ser mayor a cero.");

        if (precio <= 0)
            throw new ArgumentException("El precio del curso debe ser mayor a cero.");

        return new Curso(Guid.NewGuid(), nombre.Trim(), cantidadHoras, precio);
    }
}
