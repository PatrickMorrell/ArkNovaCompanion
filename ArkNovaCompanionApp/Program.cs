global using ArkNovaCompanionApp.Services.Interfaces;
global using Blazored.LocalStorage;
using ArkNovaCompanionApp;
using ArkNovaCompanionApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IBreakService, BreakService>();
builder.Services.AddScoped<IMoneyService, MoneyService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IActionService, ActionService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IScoreService, ScoreService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();

await builder.Build().RunAsync();
