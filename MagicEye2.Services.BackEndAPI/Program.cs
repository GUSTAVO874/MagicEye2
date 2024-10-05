using Microsoft.EntityFrameworkCore;
using MagicEye2.Services.BackEndAPI.Data;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Agregar el contexto de base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicio AutoMapper
var config = new MapperConfiguration(cfg => {
    cfg.AddProfile<MagicEye2.Services.BackEndAPI.MappingConfig>();
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

// Agregar controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// **Leer los orígenes permitidos desde la configuración**
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Usar CORS
app.UseCors("CorsPolicy");

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
