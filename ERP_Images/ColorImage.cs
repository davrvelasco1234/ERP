using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Images
{
    

    public static class ExtendBitmap
    {
        public static Bitmap ToChangeColorImage(this Bitmap bmp, Color color)
        {
            #region -> ChangeColorImage
            try
            {
                int width = bmp.Width;
                int height = bmp.Height;
                Color p;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        p = bmp.GetPixel(x, y);
                        int a = p.A;
                        int r = color.R;
                        int g = color.G;
                        int b = color.B;
                        bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                }
                return bmp;
            }
            catch { return null; }
            #endregion
        }
    }
}
