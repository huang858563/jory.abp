using System;
using System.Threading.Tasks;
using jory.abp.Domain.Configurations;
using jory.abp.ToolKits.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace jory.abp.HttpApi.Hosting
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseLog4Net()
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.UseIISIntegration()
                        .ConfigureKestrel(options =>
                        {
                            options.AddServerHeader = false;
                        })
                        .UseUrls($"https://*:{AppSettings.ListenPort}")
                        .UseStartup<Startup>();
                }).UseAutofac().Build().RunAsync();
        }
    }
}
