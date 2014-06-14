using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsr.Imaging
{
    public struct HsvPixel
    {
        public double H;
        public double S;
        public double V;

        public static explicit operator RgbPixel(HsvPixel hsvPixel)
        {
            var range = Convert.ToInt32(Math.Floor(hsvPixel.H / 60.0)) % 6;
            var f = hsvPixel.H / 60.0 - Math.Floor(hsvPixel.H / 60.0);

            var v = hsvPixel.V * 255.0;
            var p = v * (1 - hsvPixel.S);
            var q = v * (1 - f * hsvPixel.S);
            var t = v * (1 - (1 - f) * hsvPixel.S);

            switch (range)
            {
                case 0:
                    return new RgbPixel() {R = v, G = t, B = p};
                case 1:
                    return new RgbPixel() {R = q, G = v, B = p};
                case 2:
                    return new RgbPixel() {R = p, G = v, B = t};
                case 3:
                    return new RgbPixel() {R = p, G = q, B = v};
                case 4:
                    return new RgbPixel() { R = t, G = p, B = v };
            }
            return new RgbPixel() { R = v, G = p, B = q }; 
        }
    }
}
