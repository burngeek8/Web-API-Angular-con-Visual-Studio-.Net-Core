using Usuario.Api.Extensions;
using Usuario.Aplication;
using Usuario.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAuthorization();

var app = builder.Build();

app.MigrationDatabaseAsync();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //insert de prueba
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
