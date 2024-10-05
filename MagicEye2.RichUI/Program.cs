using MagicEye2.RichUI;
using MagicEye2.RichUI.Service.IService;
using MagicEye2.RichUI.Service;
using MagicEye2.RichUI.Utility;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Text;
using Microsoft.Extensions.Configuration;
using MagicEye2.RichUI;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

////////////en blazor se debe cargar así appsettings (lo creé en wwwroot) donde está mi ServiceUrls
// Crear un HttpClient para cargar el archivo de configuración
var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

// Leer el contenido de appsettings.json
using var response = await httpClient.GetAsync("appsettings.json");
if (response.IsSuccessStatusCode)
{
    using var stream = await response.Content.ReadAsStreamAsync();
    builder.Configuration.AddJsonStream(stream);
}
else
{
    throw new Exception("No se pudo cargar el archivo de configuración appsettings.json");
}
///////////////
///

// Ahora puedes acceder a la configuración
string apiBaseAddress = builder.Configuration["ServiceUrls:MaestroTBeneficiarioAPI"];
SD.MaestroTBeneficiarioAPIBase = apiBaseAddress;

// Registrar HttpClient con la dirección base correcta
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress) });

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IMaestroTBeneficiario, MaestroTBeneficiarioService>();

/////para radzen
builder.Services.AddRadzenComponents();
///

await builder.Build().RunAsync();
