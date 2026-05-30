namespace Usuario.Dominio.Usuarios.ObjectValue;

public record Password
{
    public string Value { get; init; }

    private Password(string value)
    {
        Value = value;
    }

    public static Password Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) && value.Length < 8)
            throw new ArgumentException("La contraseña no puede estar vacía, ni menor a 8.");

        return new Password(value);
    }
}
