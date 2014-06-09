using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tsr.Imaging
{
    public class RawImage
    {
        private readonly BitmapSource _bitmap;
        private readonly Pixel[,] _pixels;
        public Pixel[,] Pixels
        {
            get
            {
                return _pixels;
            }
        }

        public static RawImage FromBitmap(BitmapImage bitmap)
        {
            return new RawImage(bitmap);
        }

        private void PutRawPixels(WriteableBitmap bitmap, RawPixel[,] pixels, int x, int y)
        {
            int width = pixels.GetLength(1);
            int height = pixels.GetLength(0);
            bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, width * 4, x, y);
        }

        private RawPixel[,] GetRawPixels(BitmapSource source)
        {
            if (source.Format != PixelFormats.Bgra32)
            {
                source = new FormatConvertedBitmap(source, PixelFormats.Bgra32, null, 0);
            }

            RawPixel[,] pixels = new RawPixel[source.PixelHeight, source.PixelWidth];
            int stride = source.PixelWidth * 4;

            GCHandle pinnedPixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            source.CopyPixels(
              new Int32Rect(0, 0, source.PixelWidth, source.PixelHeight),
              pinnedPixels.AddrOfPinnedObject(),
              pixels.GetLength(0) * pixels.GetLength(1) * 4,
                  stride);
            pinnedPixels.Free();

            return pixels;
        }

        private Pixel[,] ConvertToPixels(RawPixel[,] rawPixels)
        {
            Pixel[,] pixels = new Pixel[rawPixels.GetLength(0), rawPixels.GetLength(1)];
            for (int y = 0; y < rawPixels.GetLength(0); y++)
            {
                for (int x = 0; x < rawPixels.GetLength(1); x++)
                {
                    RawPixel rawPixel = rawPixels[y, x];
                    pixels[y, x].R = rawPixel.R;
                    pixels[y, x].G = rawPixel.G;
                    pixels[y, x].B = rawPixel.B;
                    pixels[y, x].A = rawPixel.A;
                }
            }
            return pixels;
        }

        private RawPixel[,] ConvertToRawPixels(Pixel[,] pixels)
        {
            RawPixel[,] rawPixels = new RawPixel[pixels.GetLength(0), pixels.GetLength(1)];
            for (int y = 0; y < pixels.GetLength(0); y++)
            {
                for (int x = 0; x < pixels.GetLength(1); x++)
                {
                    Pixel pixel = pixels[y, x];
                    rawPixels[y, x].R = (byte)Math.Min(pixel.R, 255);
                    rawPixels[y, x].G = (byte)Math.Min(pixel.G, 255);
                    rawPixels[y, x].B = (byte)Math.Min(pixel.B, 255);
                    rawPixels[y, x].A = (byte)Math.Min(pixel.A, 255);
                }
            }
            return rawPixels;
        }

        public WriteableBitmap GetBitmap()
        {
            WriteableBitmap bitmap = new WriteableBitmap(_pixels.GetLength(1), _pixels.GetLength(0), 96, 96, PixelFormats.Bgra32, null);
            PutRawPixels(bitmap, ConvertToRawPixels(_pixels), 0, 0);
            return bitmap;
        }

        public RawImage(BitmapSource bitmap)
        {
            _bitmap = bitmap;

            RawPixel[,] rawPixels = GetRawPixels(bitmap);
            _pixels = ConvertToPixels(rawPixels);
        }
    }
}
