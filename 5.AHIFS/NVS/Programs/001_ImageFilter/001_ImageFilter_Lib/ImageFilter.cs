using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;


namespace _001_ImageFilter_Lib
{
    public static class ImageFilter
    {
        private static BitmapImage originalImage { get; set; }
        public enum colors { normal, red, green, blue};
        public enum filterTypes { none, Median3x3, Median5x5, Median7x7, Median9x9, Median11x11, Median13x13 };

        public static void setImage(BitmapImage newImage)
        {
            originalImage = newImage;
        }

        public static WriteableBitmap filterImage(colors colorType, filterTypes filterType)
        {
            Bitmap originalBitmap = ConvertBitmapImageToBitmap(originalImage);
            Bitmap resultMedian = originalBitmap;
            switch (filterType)
            {
                case filterTypes.Median3x3:
                    resultMedian = originalBitmap.MedianFilter(3);
                    break;
                case filterTypes.Median5x5:
                    resultMedian = originalBitmap.MedianFilter(5);
                    break;
                case filterTypes.Median7x7:
                    resultMedian = originalBitmap.MedianFilter(7);
                    break;
                case filterTypes.Median9x9:
                    resultMedian = originalBitmap.MedianFilter(9);
                    break;
                case filterTypes.Median11x11:
                    resultMedian = originalBitmap.MedianFilter(11);
                    break;
                case filterTypes.Median13x13:
                    resultMedian = originalBitmap.MedianFilter(13);
                    break;
            }

            BitmapImage medianImage = Convert(resultMedian);
            int bytesperpixel = medianImage.Format.BitsPerPixel / 8;
            int stride = medianImage.PixelWidth * bytesperpixel;
            byte[] pixels = new byte[stride * medianImage.PixelHeight];
            medianImage.CopyPixels(pixels, stride, 0);


            byte[] r = new byte[pixels.Length];
            byte[] g = new byte[pixels.Length];
            byte[] b = new byte[pixels.Length];

            for (int i = 0; i < pixels.Length; i = i + bytesperpixel)
            {
                b[i] = pixels[i];
                g[i + 1] = pixels[i + 1];
                r[i + 2] = pixels[i + 2];
                r[i + 3] = pixels[i + 3];
                g[i + 3] = pixels[i + 3];
                b[i + 3] = pixels[i + 3];
            }

            WriteableBitmap filteredImage = new WriteableBitmap((int)originalImage.PixelWidth, (int)originalImage.PixelHeight, originalImage.DpiX, originalImage.DpiY, originalImage.Format, null);
            var rect = new Int32Rect(0, 0, (int)originalImage.PixelWidth, (int)originalImage.PixelHeight);
            switch (colorType)
            {
                case ImageFilter.colors.normal:
                    filteredImage.WritePixels(rect, pixels, stride, 0);
                    break;
                case ImageFilter.colors.red:
                    filteredImage.WritePixels(rect, r, stride, 0);
                    break;
                case ImageFilter.colors.green:
                    filteredImage.WritePixels(rect, g, stride, 0);
                    break;
                case ImageFilter.colors.blue:
                    filteredImage.WritePixels(rect, b, stride, 0);
                    break;
            }
   
            return filteredImage;
        }

        public static Bitmap MedianFilter(this Bitmap sourceBitmap,
                                                int matrixSize,
                                                  int bias = 0,
                                         bool grayscale = false)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;


                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            List<int> neighbourPixels = new List<int>();
            byte[] middlePixel;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    neighbourPixels.Clear();

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            neighbourPixels.Add(BitConverter.ToInt32(
                                             pixelBuffer, calcOffset));
                        }
                    }

                    neighbourPixels.Sort();

                    middlePixel = BitConverter.GetBytes(
                                       neighbourPixels[filterOffset]);

                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,
                                             sourceBitmap.Height);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                        System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public static Bitmap ConvertBitmapImageToBitmap(BitmapImage bmpImg)
        {
            if (bmpImg == null)
                return null;

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bmpImg));
                enc.Save(outStream);
                return new System.Drawing.Bitmap(outStream);
            }
        }

        public static BitmapImage getImage()
        {
            return originalImage.Clone();
        }

        public static BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }
    }
}
