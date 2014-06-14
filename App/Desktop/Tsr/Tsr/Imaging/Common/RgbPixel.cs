using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tsr.Imaging
{
    public struct RgbPixel
    {
        public double B;
        public double G;
        public double R;

        public static explicit operator HsvPixel(RgbPixel rgbPixel)
        {
            double r = rgbPixel.R / 255.0d;
            double g = rgbPixel.G / 255.0d;
            double b = rgbPixel.B / 255.0d;

            double hue = 0.0d;
            double max = r, min = r;

            if (g > max) max = g;
            if (b > max) max = b;

            if (g < min) min = g;
            if (b < min) min = b;

            if (!(rgbPixel.R == rgbPixel.G && rgbPixel.G == rgbPixel.B))
            {
                double delta = max - min;
                if (r == max)
                {
                    hue = (g - b) / delta;
                }
                else if (g == max)
                {
                    hue = 2 + (b - r) / delta;
                }
                else if (b == max)
                {
                    hue = 4 + (r - g) / delta;
                }
                hue *= 60;

                if (hue < 0.0f)
                {
                    hue += 360.0f;
                }
            }

            return new HsvPixel()
            {
                H = hue,
                S = (max <= 0) ? 0 : 1d - (1d * min / max),
                V = max
            };
        }
    }
}
