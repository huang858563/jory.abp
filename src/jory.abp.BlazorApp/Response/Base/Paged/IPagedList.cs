using System;
using System.Collections.Generic;
using System.Text;

namespace jory.abp.BlazorApp.Response.Base.Paged
{
    public interface IPagedList<T> : IListResult<T>, IHasTotalCount
    {
    }
}
