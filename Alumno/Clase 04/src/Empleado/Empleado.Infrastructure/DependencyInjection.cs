using Empleado.Aplicacion.Abstractions.Data;
using Empleado.Dominio.Abstractions;
using Empleado.Dominio.Cargos;
using Empleado.Dominio.Empleados.Repository;
using Empleado.Infrastructure.Abstractions;
using Empleado.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Empleado.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddSingleton<ISqlConnectionFactory>(
            new SqlConnectionFactory(connectionString)
        );

        services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
        services.AddScoped<ICargoRepository, CargoRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
