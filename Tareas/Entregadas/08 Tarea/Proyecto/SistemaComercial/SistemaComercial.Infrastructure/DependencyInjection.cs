using SistemaComercial.Aplicacion.Abstractions.Data;
using SistemaComercial.Aplicacion.Abstractions.Security;
using SistemaComercial.Dominio.Abstractions;
using SistemaComercial.Dominio.Cargos;
using SistemaComercial.Dominio.Alumnos.Repository;
using SistemaComercial.Dominio.Cursos.Repository;
using SistemaComercial.Dominio.Empleados.Repository;
using SistemaComercial.Dominio.Ventas.Repository;
using SistemaComercial.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SistemaComercial.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SistemaComercial.Infrastructure;

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
        services.AddScoped<IAlumnoRepository, AlumnoRepository>();
        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<IVentaRepository, VentaRepository>();

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
