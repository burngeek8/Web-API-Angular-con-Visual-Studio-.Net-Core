using Empleado.Dominio.Empleados.ObjectValue;

namespace Empleado.Dominio.Empleados.Services;

public class CodigoEmpleadoServices
{
    public CodigoEmpleado GenerarCodigo(string nombres, string apellidoPaterno, DateTime fechaIngreso)
    {
        string codigo = $"{nombres.Substring(0, 1).ToUpper()}.{apellidoPaterno.ToUpper()}-{fechaIngreso.Year}";
        return CodigoEmpleado.Create(codigo);
    }
}
