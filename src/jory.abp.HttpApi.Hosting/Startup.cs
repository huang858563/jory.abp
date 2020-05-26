using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace jory.abp.HttpApi.Hosting
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<JoryAbpHttpApiHostingModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
