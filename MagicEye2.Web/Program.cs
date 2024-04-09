using MagicEye2.Web.Service.ServicioBase;
using MagicEye2.Web.Service.ServicioExpediente;
using MagicEye2.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();//este servicio se usa en baseservice
builder.Services.AddHttpClient<IExpedienteService,ExpedienteService>(); //para httpclient

SD.ExpedienteAPIBase = builder.Configuration["ServiceUrls:ExpedienteAPIBase"]; //está en appsettings

//scoped de los servicios
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IExpedienteService, ExpedienteService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
