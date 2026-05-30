namespace Usuario.Dominio.Usuarios.ObjectValue;

public class CorreoElectronico
{
    public string Value { get; private set; }
    
    private CorreoElectronico(string value)
    {
        Value = value;
    }
    public static CorreoElectronico Crear(string correo)
    {
        if (!EsCorreoValido(correo) && string.IsNullOrWhiteSpace(correo))
            throw new ArgumentException("El formato del correo electrónico es inválido o está vacío.");

        return new CorreoElectronico(correo);
    }

    private static bool EsCorreoValido(string correo)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(correo);
            return addr.Address == correo;
        }
        catch
        {
            return false;
        }
    }
}
