using AutoMapper;
using MagicEye2.Services.BackEndAPI;
using MagicEye2.Services.BackEndAPI.Data;
using MagicEye2.Services.BackEndAPI.Helpers;
using MagicEye2.Services.BackEndAPI.Services;
using MagicEye2.Services.BackEndAPI.Services.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<FileService>();//funciona pero no lo uso

builder.Services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivos>();//funciona pero no lo uso
 
builder.Services.AddTransient<ICentralStorage, CentralStorage>(); //funcionando

var app = builder.Build();

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
