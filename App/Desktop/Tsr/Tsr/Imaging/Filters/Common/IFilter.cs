﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsr.Imaging
{
    public interface IFilter
    {
        object OptionsObject { get; }
        void ApplyFilter(RawImage image);
    }
}
