using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usuario.Aplication.Abstractions.Data;
using Usuario.Dominio.Abstractions;
using Usuario.Dominio.Roles;
using Usuario.Dominio.Usuarios.Repository;
using Usuario.Infrastructure.Abstractions;
using Usuario.Infrastructure.Repositories;

namespace Usuario.Infrastructure;

public static class DependecyInjection
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

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IRolRepository, RolRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
      
        return services;
    }
}
