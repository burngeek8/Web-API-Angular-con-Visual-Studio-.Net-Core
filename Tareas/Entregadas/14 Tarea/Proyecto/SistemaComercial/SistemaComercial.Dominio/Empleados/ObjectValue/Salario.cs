namespace SistemaComercial.Dominio.Empleados.ObjectValue;

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
            throw new ArgumentException("La moneda no puede estar vacia.");

        var monedaNormalizada = moneda.Trim().ToUpperInvariant() switch
        {
            "SOL" => "PEN",
            "SOLES" => "PEN",
            "NUEVOS SOLES" => "PEN",
            "DOLAR" => "USD",
            "DOLARES" => "USD",
            _ => moneda.Trim().ToUpperInvariant()
        };

        if (monedaNormalizada.Length > 3)
            throw new ArgumentException("La moneda debe registrarse con un codigo de hasta 3 caracteres, por ejemplo PEN o USD.");

        return new Salario(monto, monedaNormalizada);
    }
}
