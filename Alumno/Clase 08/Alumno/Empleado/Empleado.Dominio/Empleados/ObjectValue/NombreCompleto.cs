namespace Empleado.Dominio.Empleados.ObjectValue;

public record NombreCompleto
{
    public string Nombres { get; init; }
    public string ApellidoPaterno { get; init; }
    public string? ApellidoMaterno { get; init; }

    private NombreCompleto()
    {
        Nombres = string.Empty;
        ApellidoPaterno = string.Empty;
    }

    private NombreCompleto(string nombres, string apellidoPaterno, string? apellidoMaterno)
    {
        Nombres = nombres;
        ApellidoPaterno = apellidoPaterno;
        ApellidoMaterno = apellidoMaterno;
    }

    public static NombreCompleto Create(string nombres, string apellidoPaterno, string? apellidoMaterno)
    {
        if (string.IsNullOrWhiteSpace(nombres))
            throw new ArgumentException("Los nombres no pueden estar vacíos.");

        if (string.IsNullOrWhiteSpace(apellidoPaterno))
            throw new ArgumentException("El apellido paterno no puede estar vacío.");

        return new NombreCompleto(nombres, apellidoPaterno, apellidoMaterno);
    }
}
