using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PaletteStudioClient;
using PaletteStudioClient.Provider;
using PaletteStudioClient.Service;
using PaletteStudioClient.Service.Palette;
using PaletteStudioClient.Utilities;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7294") });


builder.Services.AddScoped<PSAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<PSAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredLocalStorage();


//builder.Services.AddScoped<IPaletteService, PaletteService>();
//builder.Services.AddScoped<IColourService, ColourService>();



builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IClient, Client>();
builder.Services.AddScoped<IPaletteService, PaletteService>();
//builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddAutoMapper(typeof(MapperConfig));


await builder.Build().RunAsync();
