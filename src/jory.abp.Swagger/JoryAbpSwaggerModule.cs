using System;
using jory.abp.Domain;
using Microsoft.AspNetCore.Builder;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace jory.abp.Swagger
{
    [DependsOn(typeof(JoryAbpDomainModule))]
    public class JoryAbpSwaggerModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSwagger();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.GetApplicationBuilder().UseSwagger().UseSwaggerUi();
        }
    }
}
