using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tsr.Data.Entities
{
    [Serializable]
    public class Entity<TId>
    {
        public TId Id
        {
            get;
            set;
        }
    }
}
