using System;
using System.Collections.Generic;
using System.Text;
using jory.abp.Domain.Shared.Enum;

namespace jory.abp.Application.Contracts.HotNews
{
    public class HotNewsJobItem<T>
    {
        /// <summary>
        /// <see cref="Result"/>
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public HotNewsEnum Source { get; set; }
    }
}
