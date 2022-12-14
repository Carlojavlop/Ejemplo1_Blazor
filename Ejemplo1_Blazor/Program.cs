using BlazorStrap;
using Ejemplo1_Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using System.Net.NetworkInformation;


//public static async Task Main(string[] args)
//{
//    var builder = WebAssemblyHostBuilder.CreateDefault(args);
//    builder.RootComponents.Add<App>("app");

//    builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//    builder.Services.AddScoped<DialogService>();
//    builder.Services.AddScoped<NotificationService>();
//    builder.Services.AddScoped<TooltipService>();
//    builder.Services.AddScoped<ContextMenuService>();
//    await builder.Build().RunAsync();
//}

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddBlazorStrap();


builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

await builder.Build().RunAsync();
