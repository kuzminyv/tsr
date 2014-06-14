using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsr.Imaging.Filters
{
    public class HsvThresholdFilterOptions
    {
        public enum HsvComponent
        {
            Hue,
            Saturation,
            Value
        }

        public HsvComponent Component { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }

        public HsvThresholdFilterOptions()
        {
            MinValue = 0;
            MaxValue = 0.1;
        }
    }

    public class HsvThresholdFilter : Filter<HsvThresholdFilterOptions>
    {
        public override void ApplyFilter(RawImage image)
        {
            RgbPixel acceptColor = new RgbPixel() { R = 255d, G = 255d, B = 255d };
            RgbPixel rejectColor = new RgbPixel() { R = 0d, G = 0d, B = 0d };

            if (Options.Component == HsvThresholdFilterOptions.HsvComponent.Hue)
            {
                ForEachPixel(image.RgbPixels, (p, y, x) =>
                {
                    HsvPixel hsv = (HsvPixel)p;
                    if (hsv.H >= Options.MinValue && hsv.H <= Options.MaxValue)
                    {
                        return acceptColor;
                    }
                    else
                    {
                        return rejectColor;
                    }
                });
            }
            else if (Options.Component == HsvThresholdFilterOptions.HsvComponent.Saturation)
            {
                ForEachPixel(image.RgbPixels, (p, y, x) =>
                {
                    HsvPixel hsv = (HsvPixel)p;
                    if (hsv.S >= Options.MinValue && hsv.S <= Options.MaxValue)
                    {
                        return acceptColor;
                    }
                    else
                    {
                        return rejectColor;
                    }
                });
            }
            else
            {
                ForEachPixel(image.RgbPixels, (p, y, x) =>
                {
                    HsvPixel hsv = (HsvPixel)p;
                    if (hsv.V >= Options.MinValue && hsv.V <= Options.MaxValue)
                    {
                        return acceptColor;
                    }
                    else
                    {
                        return rejectColor;
                    }
                });
            }
        }
    }
}
