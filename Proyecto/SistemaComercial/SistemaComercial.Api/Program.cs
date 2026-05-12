using Microsoft.OpenApi;
using Serilog;
using SistemaComercial.Api.Extensions;
using SistemaComercial.Api.Filter;
using SistemaComercial.Aplicacion;
using SistemaComercial.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configura Serilog para registrar eventos en consola, archivo diario y MongoDB.
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.MongoDB(
        databaseUrl: builder.Configuration.GetConnectionString("MongoDb")!,
        collectionName: "logs"
    )
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddCors(options =>
    options.AddPolicy("defaultPolicy",
    corsBuilder =>
    {
        corsBuilder.WithOrigins("http://localhost:5500", "http://127.0.0.1:5500")
            .AllowAnyHeader()
            .AllowAnyMethod();
    }));

// Registro de filtros globales: control de excepciones y logging de acciones
builder.Services.AddScoped<GlobalExceptionFilter>();
builder.Services.AddScoped<GlobalActionLoggingFilter>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<GlobalActionLoggingFilter>();
});


builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    opt.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.MigrationDatabaseAsync();

app.UseCors("defaultPolicy");

app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;
    if (response.StatusCode == StatusCodes.Status401Unauthorized ||
        response.StatusCode == StatusCodes.Status403Forbidden)
    {
        response.ContentType = "application/json";
        var problem = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = response.StatusCode,
            Title = response.StatusCode == StatusCodes.Status401Unauthorized
                ? "No autenticado."
                : "Acceso denegado. No tiene permisos para este recurso.",
        };
        await response.WriteAsJsonAsync(problem);
    }
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
