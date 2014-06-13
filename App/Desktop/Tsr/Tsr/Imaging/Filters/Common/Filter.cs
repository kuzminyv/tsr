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

        /// <summary>
        /// Calls func for each pixel
        /// </summary>
        /// <param name="func">func args: pixel, y, x</param>
        protected void ForEachPixel(Pixel[,] pixels, Func<Pixel, int, int, Pixel> func)
        {
            for (int y = 0; y < pixels.GetLength(0); y++)
            {
                for (int x = 0; x < pixels.GetLength(1); x++)
                {
                    pixels[y, x] = func(pixels[y, x], y, x);
                }
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
