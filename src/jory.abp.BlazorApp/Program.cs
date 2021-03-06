using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using jory.abp.BlazorApp.Commons;

namespace jory.abp.BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var baseAddress = "https://localhost:5001";

            if (builder.HostEnvironment.IsProduction())
                baseAddress = " https://localhost:5001";

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

            builder.Services.AddSingleton(typeof(Common));

            await builder.Build().RunAsync();
        }
    }
}
