using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsr.Imaging
{
    public abstract class Filter<TOptions> : IFilter 
        where TOptions : class, new()  
    {
        private readonly TOptions _options;
        public TOptions Options
        {
            get
            {
                return _options;
            }
        }

        public Filter(TOptions options)
        {
            _options = options;
        }

        public Filter()
            : this(new TOptions())
        { 
        }

        public abstract void ApplyFilter(RawImage image);
    }
}
