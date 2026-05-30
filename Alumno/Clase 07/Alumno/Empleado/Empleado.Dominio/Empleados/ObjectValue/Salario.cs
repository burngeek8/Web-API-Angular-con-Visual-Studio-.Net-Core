namespace Empleado.Dominio.Empleados.ObjectValue;

public record Salario
{
    public decimal Monto { get; init; }
    public string Moneda { get; init; }

    private Salario()
    {
        Moneda = string.Empty;
    }

    private Salario(decimal monto, string moneda)
    {
        Monto = monto;
        Moneda = moneda;
    }

    public static Salario Create(decimal monto, string moneda)
    {
        if (monto <= 0)
            throw new ArgumentException("El salario debe ser mayor a cero.");

        if (string.IsNullOrWhiteSpace(moneda))
            throw new ArgumentException("La moneda no puede estar vacía.");

        return new Salario(monto, moneda);
    }
}
