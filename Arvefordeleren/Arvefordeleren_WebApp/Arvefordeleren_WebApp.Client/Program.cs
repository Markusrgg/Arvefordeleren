using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;

namespace Arvefordeleren_WebApp.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("7084") }); 

            await builder.Build().RunAsync();
            await builder.Build().RunAsync();
        }
    }
}
