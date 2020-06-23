using System;
using System.Collections.Generic;
using System.Text;

namespace jory.abp.BlazorApp.Response.Base.Paged
{
    public class ListResult<T> : IListResult<T>
    {
        IReadOnlyList<T> _items;

        public IReadOnlyList<T> Items
        {
            get => _items ??= new List<T>();
            set => _items = value;
        }

        public ListResult()
        {
        }

        public ListResult(IReadOnlyList<T> items)
        {
            Items = items;
        }
    }
}
