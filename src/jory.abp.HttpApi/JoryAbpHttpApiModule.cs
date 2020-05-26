using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace jory.abp
{
    [DependsOn(typeof(AbpIdentityHttpApiModule),
        typeof(JoryAbpApplicationModule)
    )]
    public class JoryAbpHttpApiModule : AbpModule
    {

    }
}
