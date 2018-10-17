using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace _001_ImageFilter_Lib
{
    public class ImageFilter
    {
        private BitmapImage originalImage { get; set; }
        public enum colors { normal, red, green, blue};
        public enum filterTypes { none, Median};

        public void setImage(BitmapImage newImage)
        {
            this.originalImage = newImage;
        }

        public WriteableBitmap filterImage(colors colorType, filterTypes filterType, int m, int n)
        {
            int bytesperpixel = originalImage.Format.BitsPerPixel / 8;
            int stride = originalImage.PixelWidth * bytesperpixel;
            byte[] pixels = new byte[stride * originalImage.PixelHeight];
            originalImage.CopyPixels(pixels, stride, 0);



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

            for



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

        public BitmapImage getImage()
        {
            return this.originalImage.Clone();
        }
    }
}
