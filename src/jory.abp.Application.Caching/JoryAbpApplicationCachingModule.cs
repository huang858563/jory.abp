using jory.abp.Domain;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace jory.abp.Application.Caching
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(JoryAbpDomainModule)
    )]
    public class JoryAbpApplicationCachingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
