using FluentValidation;
using MediatR;
using SistemaComercial.Aplicacion.Abstractions.Behaviors;
using SistemaComercial.Dominio.Empleados.Services;
using Microsoft.Extensions.DependencyInjection;

namespace SistemaComercial.Aplicacion;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddTransient<CodigoEmpleadoServices>();
        services.AddTransient<ClaveEmpleadoService>();
        return services;
    }
}
