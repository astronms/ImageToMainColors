using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingLib
{

    public static class ImageProcessing
    {
        public static BitmapSource ToMainColorsSync(BitmapSource bitmapSource)
        {
            var pixels = GetBitmapPixels(bitmapSource);
            pixels = ConvertPixelsToMainColorsSync(pixels);
            return CreateImage(bitmapSource, pixels);
        }
        public static async Task<BitmapSource> ToMainColorsAsync(BitmapSource bitmapSource)
        {
            var pixels = GetBitmapPixels(bitmapSource);
            pixels = await ConvertPixelsToMainColorsAsync(pixels);
            return CreateImage(bitmapSource, pixels);
        }

        public static byte[] GetBitmapPixels(BitmapSource bitmapSource)
        {
            var stride = GetStride(bitmapSource);

            var pixels = new byte[bitmapSource.PixelHeight * stride];
            bitmapSource.CopyPixels(pixels, stride, 0);
            return pixels;
        }
        private static int GetStride(BitmapSource bitmapSource)
        {
            return bitmapSource.PixelWidth * (bitmapSource.Format.BitsPerPixel / 8);
        }
        private static byte[] ConvertPixelsToMainColorsSync(byte[] pixels)
        {
            for (var i = 0; i < pixels.Length; i += 4)
            {
                if (pixels[i] > pixels[i + 1] && pixels[i] > pixels[i + 2])
                {
                    pixels[i] = 255;
                    pixels[i + 1] = pixels[i + 2] = 0;
                     
                }
                if (pixels[i + 1] > pixels[i] && pixels[i + 1] > pixels[i + 2])
                {
                    pixels[i + 1] = 255;
                    pixels[i]= pixels[i + 2] = 0;
                }
                if (pixels[i + 2] > pixels[i + 1] && pixels[i + 2] > pixels[i])
                {
                    pixels[i + 2] = 255; 
                    pixels[i] = pixels[i + 1] = 0;
                }
            }
            return pixels;
        }
        private static async Task<byte[]> ConvertPixelsToMainColorsAsync(byte[] pixels)
        {

            var Task1 = Task.Run(() =>
            {
                for (var i = 0; i < pixels.Length/2; i += 4)
                {
                    if (pixels[i] > pixels[i + 1] && pixels[i] > pixels[i + 2])
                    {
                        pixels[i] = 255;
                        pixels[i + 1] = pixels[i + 2] = 0;

                    }
                    if (pixels[i + 1] > pixels[i] && pixels[i + 1] > pixels[i + 2])
                    {
                        pixels[i + 1] = 255;
                        pixels[i] = pixels[i + 2] = 0;
                    }
                    if (pixels[i + 2] > pixels[i + 1] && pixels[i + 2] > pixels[i])
                    {
                        pixels[i + 2] = 255;
                        pixels[i] = pixels[i + 1] = 0;
                    }
                    
                }
            });
            var Task2 = Task.Run(() =>
            {
                for (var i = pixels.Length / 2; i < pixels.Length ; i += 4)
                {
                    if (pixels[i] > pixels[i + 1] && pixels[i] > pixels[i + 2])
                    {
                        pixels[i] = 255;
                        pixels[i + 1] = pixels[i + 2] = 0;

                    }
                    if (pixels[i + 1] > pixels[i] && pixels[i + 1] > pixels[i + 2])
                    {
                        pixels[i + 1] = 255;
                        pixels[i] = pixels[i + 2] = 0;
                    }
                    if (pixels[i + 2] > pixels[i + 1] && pixels[i + 2] > pixels[i])
                    {
                        pixels[i + 2] = 255;
                        pixels[i] = pixels[i + 1] = 0;
                    }
                }
            });
            await Task.WhenAll(Task1, Task2);
            return pixels;
        }

        private static BitmapSource CreateImage(BitmapSource inputBitmapSource, byte[] pixels)
        {
            var stride = GetStride(inputBitmapSource);
            var outputBitmapSource = BitmapSource.Create(inputBitmapSource.PixelWidth, inputBitmapSource.PixelHeight,
                inputBitmapSource.DpiX, inputBitmapSource.DpiY, inputBitmapSource.Format, inputBitmapSource.Palette,
                pixels, stride);
            outputBitmapSource.Freeze();
            return outputBitmapSource;
        }



    }
}
