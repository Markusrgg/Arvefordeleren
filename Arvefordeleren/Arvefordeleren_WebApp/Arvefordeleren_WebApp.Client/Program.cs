using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;

namespace Arvefordeleren_WebApp.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            await builder.Build().RunAsync();
        }
    }
}
