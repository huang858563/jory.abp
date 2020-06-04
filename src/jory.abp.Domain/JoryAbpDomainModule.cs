using System;
using System.Collections.Generic;
using System.Text;
using jory.abp.Domain.Shared;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace jory.abp.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule),typeof(JoryAbpDomainSharedModule))]
    public  class JoryAbpDomainModule:AbpModule
    {
    }
}
