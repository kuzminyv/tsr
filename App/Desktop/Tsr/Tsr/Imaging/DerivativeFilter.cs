using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsr.Imaging
{
    public class DerivativeFilter: IFilter
    {
        public RawImage ApplyFilter(RawImage image)
        {
            for (int y = 0; y < image.Pixels.GetLength(0); y++)
            {
                for (int x = 0; x < image.Pixels.GetLength(1) - 1; x++)
                {
                    long k = 20;
                    image.Pixels[y, x].R = Math.Abs(255 - (image.Pixels[y, x].R - image.Pixels[y, x + 1].R)*k);
                    image.Pixels[y, x].G = Math.Abs(255 - (image.Pixels[y, x].G - image.Pixels[y, x + 1].G)*k);
                    image.Pixels[y, x].B = Math.Abs(255 - (image.Pixels[y, x].B - image.Pixels[y, x + 1].B)*k);
                }
            }
            return image;

        }

        public static RawImage Apply(RawImage image)
        {
            return (new DerivativeFilter().ApplyFilter(image));
        }
    }
}
