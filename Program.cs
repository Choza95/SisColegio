using Microsoft.OpenApi;
using SisColegio.Interfaces;
using SisColegio.Mapping;
using SisColegio.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Repositorios y servicios
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// AutoMapper (escanea todos los perfiles en los ensamblados del proyecto)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Controladores
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SisColegio API",
        Version = "v1",
        Description = "API para gestión del sistema de colegio"
    });
});

var app = builder.Build();

// Middleware de Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
    c.SwaggerEndpoint("/swagger/v1/swagger