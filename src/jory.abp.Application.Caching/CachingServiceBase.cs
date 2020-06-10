using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.DependencyInjection;

namespace jory.abp.Application.Caching
{
    public class CachingServiceBase: ITransientDependency
    {
        public IDistributedCache Cache { get; set; }
    }

}
