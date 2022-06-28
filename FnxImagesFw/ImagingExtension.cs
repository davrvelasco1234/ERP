using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FnxImagesFw
{
    public static class ImagingExtension
    {
        public static ImageSource GetImageSource(string img)
            => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject(img))).ToBitmapImage();


        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        

        public static Bitmap ToBitmap(this BitmapImage bitmapImage)
        {
            using (var memory = new MemoryStream())
            {
                var encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(memory);
                var bitmap = new Bitmap(memory);

                return new Bitmap(bitmap);
            }
        }

        public static Image ToImage(this byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        public static ImageSource ToImageSource(this System.Drawing.Image image, ImageFormat imageFormat)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapImage bitmap = new BitmapImage();

                // Save to the stream
                image.Save(stream, imageFormat);

                // Rewind the stream
                stream.Seek(0, SeekOrigin.Begin);

                // Tell the WPF BitmapImage to use this stream
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                return bitmap;
            }
        }


    }
}
