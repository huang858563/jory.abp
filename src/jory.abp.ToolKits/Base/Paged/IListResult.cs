﻿using System;
using System.Collections.Generic;
using System.Text;

namespace jory.abp.ToolKits.Base.Paged
{
    public interface IListResult<T>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        IReadOnlyList<T> Items { get; set; }
    }
}
