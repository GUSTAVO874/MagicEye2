using MagicEye2.Web.Service.IService;
using MagicEye2.Web.Service;
using MagicEye2.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
//quitar línea de abajo luego de probar
builder.Services.AddHttpClient<IMaestroTBeneficiario, MaestroTBeneficiarioService>();
SD.MaestroTBeneficiarioAPIBase = builder.Configuration["ServiceUrls:MaestroTBeneficiarioAPI"];

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IMaestroTBeneficiario, MaestroTBeneficiarioService>();


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
