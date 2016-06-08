using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aruco_Marker_Detecter
{
    public class MarkerHandler
    {
        public string DirectoryPath = null;
        public Dictionary<string,Bitmap> Markers = new Dictionary<string, Bitmap>();
        public MarkerHandler(string path)
        {
            DirectoryPath = path;
        }
        public Dictionary<string,Bitmap> GetMarkers()
        {
            
            string[] avMarkers = Directory.GetFiles(DirectoryPath);
            string currentId = null;
            
            foreach (var item in avMarkers)
            {
                
                Bitmap marker = new Bitmap(item);
                string fileName = new FileInfo(item).Name;
                currentId = fileName.Substring(0, fileName.IndexOf("."));
                Markers.Add(currentId,ChangePixalFormateStyle(marker));
            }
            return Markers;
        }

        private Bitmap ChangePixalFormateStyle(Bitmap marker)
        {
            Bitmap changed = marker.Clone(new Rectangle(0, 0, marker.Width, marker.Height), PixelFormat.Format24bppRgb);
            return changed;
        }
    }
}
