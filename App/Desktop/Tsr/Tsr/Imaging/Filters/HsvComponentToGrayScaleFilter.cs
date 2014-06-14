using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsr.Imaging.Filters
{
    public class HsvComponentToGrayScaleFilterOptions
    {
        public enum HsvComponent
        {
            Hue,
            Saturation,
            Value
        }

        public HsvComponent Component { get; set; } 
    }

    public class HsvComponentToGrayScaleFilter : Filter<HsvComponentToGrayScaleFilterOptions>
    {
        public override void ApplyFilter(RawImage image)
        {
            if (Options.Component == HsvComponentToGrayScaleFilterOptions.HsvComponent.Hue)
            {
                ForEachPixel(image.RgbPixels, (p, y, x) =>
                {
                    HsvPixel hsv = (HsvPixel)p; 
                    return new RgbPixel() { R = hsv.H, G = hsv.H, B = hsv.H };
                });
            }
            else if (Options.Component == HsvComponentToGrayScaleFilterOptions.HsvComponent.Saturation)
            {
                ForEachPixel(image.RgbPixels, (p, y, x) =>
                {
                    HsvPixel hsv = (HsvPixel)p; hsv.S *= 255d;
                    return new RgbPixel() { R = hsv.S, G = hsv.S, B = hsv.S };
                });
            }
            else
            {
                ForEachPixel(image.RgbPixels, (p, y, x) =>
                {
                    HsvPixel hsv = (HsvPixel)p; hsv.V *= 255d;
                    return new RgbPixel() { R = hsv.V, G = hsv.V, B = hsv.V };
                });
            }
        }
    }
}
