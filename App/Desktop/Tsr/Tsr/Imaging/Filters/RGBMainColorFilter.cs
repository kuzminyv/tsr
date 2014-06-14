using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsr.Imaging.Filters
{
    public class MainColorFilterOptions
    {
    }
    public class RGBMainColorFilter :Filter<MainColorFilterOptions>
    {
        public override void ApplyFilter(RawImage image)
        {
            ForEachPixel(image.RgbPixels, (p, y, x) =>
            {
                if (p.R > p.G && p.R > p.B)
                {
                    p.R = 255;
                    p.G = 0;
                    p.B = 0;
                }
                else if (p.G > p.R && p.G > p.B)
                {
                    p.R = 0;
                    p.G = 255;
                    p.B = 0;
                }
                else if (p.B > p.R && p.B > p.G)
                {
                    p.R = 0;
                    p.G = 0;
                    p.B = 255;
                }
                else
                {
                    p.R = 255;
                    p.G = 255;
                    p.B = 255;
                }
                return p;
            });
        }
    }
}
