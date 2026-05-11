using Usuario.Api.Extensions;
using Usuario.Api.Filter;
using Usuario.Aplication;
using Usuario.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors( options =>
        options.AddPolicy("defaultPolicy", 
        builder =>
        {
            builder.WithOrigins("http://localhost:5500", "http://127.0.0.1:5500")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        }));

builder.Services.AddScoped<GlobalExceptionFilter>();
builder.Services.AddScoped<GlobalActionLoggingFilter>();


builder.Services.AddControllers(option =>
{
    option.Filters.Add<GlobalExceptionFilter>();
    option.Filters.Add<GlobalActionLoggingFilter>();
});

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

app.UseCors("defaultPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
