using Microsoft.EntityFrameworkCore;
using MagicEye2.Services.BackEndAPI.Data;
using AutoMapper;



var builder = WebApplication.CreateBuilder(args);

// Agregar el contexto de base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//registrar servicio automapper
var config = new MapperConfiguration(cfg => {
    cfg.AddProfile<MagicEye2.Services.BackEndAPI.MappingConfig>();
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

///////////////

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configurar CORS para que las diferentes instancias se conecten a mis endpoints
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("https://localhost:7239") // Puerto de mi Blazor WebAssembly
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Agregar servicios al contenedor
builder.Services.AddControllers();


var app = builder.Build();

// Usar CORS
app.UseCors("CorsPolicy");

//////////////////////////////////

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
