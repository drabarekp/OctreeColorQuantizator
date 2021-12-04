using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GK3
{
    public class GreyScaleMaker
    {
        public Bitmap CreateGreyscaleImage(Bitmap bitmap)
        {
            Bitmap result = new Bitmap(bitmap);

            for(int x = 0; x < result.Width; x++)
            {
                for(int y=0; y < result.Height; y++)
                {
                    result.SetPixel(x, y, GreyscaleFromColor(result.GetPixel(x, y)));
                }
            }

            return result;
        }
        private Color GreyscaleFromColor(Color color)
        {
            double red = (double)color.R;
            double green = (double)color.G;
            double blue = (double)color.B;

            double grey = red * 0.299 + green * 0.587 + blue * 0.114;
            return Color.FromArgb((int)grey, (int)grey, (int)grey);
        }
    }
}
