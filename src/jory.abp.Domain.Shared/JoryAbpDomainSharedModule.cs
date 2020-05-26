
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace jory.abp.Domain.Shared
{
    [DependsOn(
        typeof(AbpIdentityDomainSharedModule)
    )]
    public class JoryAbpDomainSharedModule : AbpModule
    {
    }
}
