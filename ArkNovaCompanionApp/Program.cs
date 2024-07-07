using ArkNovaCompanionApp;
using ArkNovaCompanionApp.Services;
using ArkNovaCompanionApp.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ICollectionsService, CollectionsService>();
builder.Services.AddScoped<IBreakService, BreakService>();

await builder.Build().RunAsync();
