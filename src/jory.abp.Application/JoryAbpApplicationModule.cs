using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace jory.abp
{
    [DependsOn(typeof(AbpIdentityApplicationModule))]
    public class JoryAbpApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           }
    }
}
