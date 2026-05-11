using SistemaComercial.Dominio.Abstractions;

namespace SistemaComercial.Dominio.Ventas;

public class Venta : Entity
{
    private readonly List<DetalleVenta> _detalles = [];

    public string Serie { get; private set; }
    public int Numero { get; private set; }
    public Guid AlumnoId { get; private set; }
    public DateTime Fecha { get; private set; }
    public decimal Total { get; private set; }

    public Dominio.Alumnos.Alumno? Alumno { get; private set; }
    public IReadOnlyCollection<DetalleVenta> Detalles => _detalles.AsReadOnly();

    private Venta()
    {
        Serie = string.Empty;
    }

    private Venta(Guid id, string serie, int numero, Guid alumnoId, DateTime fecha, List<DetalleVenta> detalles) : base(id)
    {
        Serie = serie;
        Numero = numero;
        AlumnoId = alumnoId;
        Fecha = fecha;
        _detalles = detalles;
        Total = detalles.Sum(x => x.Total);
    }

    public static Venta Create(Guid alumnoId, DateTime fecha, string serie, int numero, IEnumerable<DetalleVenta> detalles)
    {
        if (alumnoId == Guid.Empty)
            throw new ArgumentException("El alumno de la venta es obligatorio.");

        if (string.IsNullOrWhiteSpace(serie))
            throw new ArgumentException("La serie de la venta es obligatoria.");

        if (numero <= 0)
            throw new ArgumentException("El numero de la venta debe ser mayor a cero.");

        var detallesList = detalles.ToList();
        if (detallesList.Count == 0)
            throw new ArgumentException("La venta debe tener al menos un detalle.");

        return new Venta(Guid.NewGuid(), serie.Trim().ToUpperInvariant(), numero, alumnoId, fecha, detallesList);
    }
}
