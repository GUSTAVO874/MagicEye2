using MagicEye2.RichUI2;
using MagicEye2.RichUI2.Service.IService;
using MagicEye2.RichUI2.Service;
using MagicEye2.RichUI2.Utility;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddHttpClient(); quitar esta línea
//
//builder.Services.AddHttpClient<IMaestroTBeneficiario, MaestroTBeneficiarioService>();
//SD.MaestroTBeneficiarioAPIBase = builder.Configuration["ServiceUrls:MaestroTBeneficiarioAPI"];

SD.MaestroTBeneficiarioAPIBase = "https://localhost:7001"; //puerto donde se ejecuta mi end api

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ServiceUrls:MaestroTBeneficiarioAPI"]) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7001") });


builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IMaestroTBeneficiario, MaestroTBeneficiarioService>();

await builder.Build().RunAsync();
