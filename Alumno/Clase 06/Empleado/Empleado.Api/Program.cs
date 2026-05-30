using Empleado.Api.Extensions;
using Empleado.Aplicacion;
using Empleado.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await app.MigrationDatabaseAsync();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
