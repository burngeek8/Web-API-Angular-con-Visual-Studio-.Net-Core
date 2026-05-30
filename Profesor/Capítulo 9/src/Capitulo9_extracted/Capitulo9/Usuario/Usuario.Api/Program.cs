using Microsoft.OpenApi;
using Serilog;
using Usuario.Api.Extensions;
using Usuario.Api.Filter;
using Usuario.Aplication;
using Usuario.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

Log.Logger  = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.MongoDB(
        databaseUrl: builder.Configuration.GetConnectionString("MongoDb")!,
        collectionName: "logs"
    )
    .CreateLogger();

builder.Host.UseSerilog();

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    opt =>
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
            [ new OpenApiSecuritySchemeReference("Bearer", document )  ] = []
        });
    });
    

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAuthorization();

var app = builder.Build();

app.MigrationDatabaseAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("defaultPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
