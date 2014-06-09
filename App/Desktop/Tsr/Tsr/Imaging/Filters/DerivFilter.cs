using OpenCV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsr.Imaging
{
    public class DerivFilterOptions
    {
        public int Dx { get; set;}
        public int Dy { get; set; }

        public DerivFilterOptions()
        {
            Dx = 1;
            Dy = 0;
        }
    }


    public class DerivFilter: Filter<DerivFilterOptions>
    {
        public override void ApplyFilter(RawImage image)
        {
            var dx = Options.Dx;
            var dy = Options.Dy;

            for (int y = 0; y < image.Pixels.GetLength(0) - dy; y++)
            {
                for (int x = 0; x < image.Pixels.GetLength(1) - dx; x++)
                {
                    double k = 1; 
                    image.Pixels[y, x].R = (255 - Math.Abs(image.Pixels[y, x].R - image.Pixels[y + dy, x + dx].R));
                    image.Pixels[y, x].G = (255 - Math.Abs(image.Pixels[y, x].G - image.Pixels[y + dy, x + dx].G));
                    image.Pixels[y, x].B = (255 - Math.Abs(image.Pixels[y, x].B - image.Pixels[y + dy, x + dx].B));
                }
            }
        }
    }
}
