using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace jory.abp.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public  class JoryAbpDomainModule:AbpModule
    {
    }
}
