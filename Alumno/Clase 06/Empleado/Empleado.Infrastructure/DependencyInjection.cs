using Empleado.Aplicacion.Abstractions.Data;
using Empleado.Aplicacion.Abstractions.Security;
using Empleado.Dominio.Abstractions;
using Empleado.Dominio.Cargos;
using Empleado.Dominio.Empleados.Repository;
using Empleado.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
        var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>()
            ?? throw new InvalidOperationException("JWT configuration section is missing or invalid.");

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

        services.AddSingleton(jwtOptions);
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(jwtOptions.SecretKey)
                    ),
                    ClockSkew = TimeSpan.Zero
                };
            });

        return services;
    }
}
