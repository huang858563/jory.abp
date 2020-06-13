using jory.abp.Application.Caching;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace jory.abp.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(AbpAutoMapperModule),
        typeof(JoryAbpApplicationCachingModule))]
    public class JoryAbpApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<JoryAbpApplicationModule>(validate: true);
                options.AddProfile<JoryAbpAutoMapperProfile>(validate: true);
            });
        }
    }
}
