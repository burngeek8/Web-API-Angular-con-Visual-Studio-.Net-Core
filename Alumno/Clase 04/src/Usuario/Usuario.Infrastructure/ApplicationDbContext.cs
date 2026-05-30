using Microsoft.EntityFrameworkCore;
using Usuario.Dominio.Abstractions;

namespace Usuario.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
