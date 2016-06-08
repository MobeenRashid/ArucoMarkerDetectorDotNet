using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aruco_Marker_Detecter
{
    public class ImageHandler
    {
        public string ImagePath = null;
        private Bitmap image = null;

        private static ImageHandler imageObj = null;
                                     
        public Bitmap ChoosedImage
        {
            get
            {
                ConvertToBlackAndWhite(image);
                return image.Clone(new Rectangle(0, 0, image.Width, image.Height), PixelFormat.Format24bppRgb);
            }
            set { image = value; }
        }

        private ImageHandler()
        {

        }
        public static ImageHandler GetImageObj()
        {
            imageObj = new ImageHandler();
            return imageObj;
        }
       public Bitmap ConvertToBlackAndWhite(Bitmap imagePix)
        {
            Color c;
            int rgb;
            for (int i = 0; i < imagePix.Width; i++)
            {
                for (int j = 0; j < imagePix.Height; j++)
                {
                    c = imagePix.GetPixel(i, j);
                    rgb = (int)((c.R + c.G + c.B) / 3);
                    imagePix.SetPixel(i, j, Color.FromArgb(rgb, rgb, rgb));
                }
            }   
            return imagePix;
        }
    }
}
