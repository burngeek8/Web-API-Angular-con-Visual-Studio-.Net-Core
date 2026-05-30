namespace Usuario.Dominio.Usuarios.ObjectValue;

public record NombreUsuario
{
    public string Value { get; init; }
    private NombreUsuario(string value)
    {
        Value = value;
    }
    public static NombreUsuario Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) && value.Length < 3)
            throw new ArgumentException("El nombre de usuario no puede estar vacío, ni menor a 5.");
        
        return new NombreUsuario(value);
    }
}
