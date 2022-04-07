using LectorUniversal.Client;
using LectorUniversal.Client.Repository;
using LectorUniversal.Client.Helpers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("LectorUniversal.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("LectorUniversal.ServerAPI"));

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IShowMessages, ShowMessages>();
builder.Services.AddFileReaderService(opt => opt.InitializeOnFirstCall = true);

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
