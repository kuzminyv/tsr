using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tsr.Data.Common
{
    public class QueryResult<TEntity>
    {
        public List<TEntity> Items
        {
            get;
            set;
        }

        public int? TotalCount
        {
            get;
            set;
        }

        public QueryResult(List<TEntity> items, int? totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }

        public QueryResult(List<TEntity> items)
            : this(items, null)
        { 
        }
    }
}
