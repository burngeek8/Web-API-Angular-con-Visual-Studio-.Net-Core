using SistemaComercial.Dominio.Abstractions;

namespace SistemaComercial.Dominio.Ventas;

public class DetalleVenta : Entity
{
    public Guid VentaId { get; private set; }
    public Guid CursoId { get; private set; }
    public int Cantidad { get; private set; }
    public decimal Precio { get; private set; }
    public decimal Total { get; private set; }

    public Dominio.Cursos.Curso? Curso { get; private set; }

    private DetalleVenta()
    {
    }

    private DetalleVenta(Guid id, Guid cursoId, int cantidad, decimal precio) : base(id)
    {
        CursoId = cursoId;
        Cantidad = cantidad;
        Precio = precio;
        Total = cantidad * precio;
    }

    public static DetalleVenta Create(Guid cursoId, int cantidad, decimal precio)
    {
        if (cursoId == Guid.Empty)
            throw new ArgumentException("El curso del detalle es obligatorio.");

        if (cantidad <= 0)
            throw new ArgumentException("La cantidad del detalle debe ser mayor a cero.");

        if (precio <= 0)
            throw new ArgumentException("El precio del detalle debe ser mayor a cero.");

        return new DetalleVenta(Guid.NewGuid(), cursoId, cantidad, precio);
    }
}
