using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortalAlunoWeb_Front;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using PortalAlunoWeb_Front.Service;



var builder = WebAssemblyHostBuilder.CreateDefault(args);



builder.RootComponents.Add<App>("app");

builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<ToastService>();



builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();


builder.Services.AddCors(policy =>
{
    policy.AddPolicy("_myAllowSpecificOrigins", builder => builder.WithOrigins("https://localhost:7133/")
         .AllowAnyMethod()
         .AllowAnyHeader()
         .AllowCredentials());
});

await builder.Build().RunAsync();
