using Microsoft.Extensions.DependencyInjection;
using Usuario.Dominio.Usuarios.Services;

namespace Usuario.Aplication;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddTransient<NombreUsuarioServices>();
        return services;
    }
}
