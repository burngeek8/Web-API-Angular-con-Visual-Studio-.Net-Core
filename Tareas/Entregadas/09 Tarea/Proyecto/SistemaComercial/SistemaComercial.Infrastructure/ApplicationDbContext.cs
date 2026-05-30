using SistemaComercial.Dominio.Abstractions;
using SistemaComercial.Dominio.Alumnos;
using SistemaComercial.Dominio.Cursos;
using SistemaComercial.Dominio.Ventas;
using Microsoft.EntityFrameworkCore;

namespace SistemaComercial.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Alumno> Alumnos => Set<Alumno>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<DetalleVenta> DetallesVenta => Set<DetalleVenta>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
