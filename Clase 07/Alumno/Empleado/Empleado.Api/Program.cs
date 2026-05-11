using Empleado.Api.Extensions;
using Empleado.Api.Filter;
using Empleado.Aplicacion;
using Empleado.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    options.AddPolicy("defaultPolicy",
    corsBuilder =>
    {
        corsBuilder.WithOrigins("http://localhost:5500", "http://127.0.0.1:5500")
            .AllowAnyHeader()
            .AllowAnyMethod();
    }));

builder.Services.AddScoped<GlobalExceptionFilter>();
builder.Services.AddScoped<GlobalActionLoggingFilter>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<GlobalActionLoggingFilter>();
});
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

app.UseCors("defaultPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
