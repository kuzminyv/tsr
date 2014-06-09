using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsr.Imaging
{
    public interface IFilter
    {
        RawImage ApplyFilter(RawImage image);
    }
}
