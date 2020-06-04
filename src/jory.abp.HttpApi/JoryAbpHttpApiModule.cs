using jory.abp.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace jory.abp.HttpApi
{
    [DependsOn(typeof(AbpIdentityHttpApiModule),
        typeof(JoryAbpApplicationModule)
    )]
    public class JoryAbpHttpApiModule : AbpModule
    {

    }
}
