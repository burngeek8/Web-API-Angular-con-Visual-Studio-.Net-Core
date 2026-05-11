namespace Empleado.Dominio.Empleados.ObjectValue;

public record CodigoEmpleado
{
    public string Valor { get; init; }

    private CodigoEmpleado(string valor)
    {
        Valor = valor;
    }

    public static CodigoEmpleado Create(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("El código del empleado no puede estar vacío.");

        return new CodigoEmpleado(valor);
    }
}
