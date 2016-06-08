using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aruco_Marker_Detecter
{
    public class ImageAnalyzer
    {
        public void StartAnalysis(MainForm mainForm, Bitmap choosedImage)
        {

            try
            {
                string[] avMarkers = Directory.GetFiles(MainForm.DirectoryPath);
                FileInfo fileInfo = null;
                for (int i = 0; i < avMarkers.Length; i++)
                {
                    Bitmap currentMaker = new Bitmap(avMarkers[i]);
                    Bitmap fixedPixels = currentMaker.Clone(new Rectangle(0, 0, currentMaker.Width, currentMaker.Height), PixelFormat.Format24bppRgb);

                    fileInfo = new FileInfo(avMarkers[i]);
                    string fileName = fileInfo.Name;
                    string currentId = fileName.Substring(0, fileName.IndexOf("."));

                    PerformLongRunningOperations(mainForm, choosedImage, fixedPixels, currentId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Some thing Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                mainForm.Invoke((MethodInvoker)delegate
                {                                       
                    mainForm.metroProgressSpinner1.Visible = false;
                    mainForm.txtProgress.Visible = false;
                });

                if (!(MainForm.dataTable.Rows.Count > 0))
                {
                    MessageBox.Show("Macth Not Founded", "Match Result", MessageBoxButtons.OK, MessageBoxIcon
                        .Information);
                }
            }
        }

        public void PerformLongRunningOperations(MainForm obj, Bitmap currentImage, Bitmap currentMarker, string currentId)
        {
            ExhaustiveTemplateMatching etm = new ExhaustiveTemplateMatching(0.9f);
            Thread.Sleep(1000);
            TemplateMatch[] matches = etm.ProcessImage(currentImage, currentMarker);
            ContinuationMethod(obj, matches, currentId, currentImage);
        }
        public void ContinuationMethod(MainForm obj, TemplateMatch[] matches, string makerId, Bitmap currentImage)
        {
            if (matches.Count() > 0)
            {
                for (int i = 0; i < matches.Count(); i++)
                {
                    DrawRedRectangles(obj, matches[i], currentImage, makerId);
                }
            }

        }
        public void DrawRedRectangles(MainForm obj, TemplateMatch matches, Bitmap currentImage, string markerId)
        {
            int matchX = matches.Rectangle.X;
            int matchY = matches.Rectangle.Y;
            int rectWidth = matches.Rectangle.Width;
            int rectHeight = matches.Rectangle.Height;


            obj.Invoke((MethodInvoker)delegate
            {
                MainForm.dataTable.Rows.Add(markerId);
            });

            Pen redPen = new Pen(Color.Red);
            Brush brush = new SolidBrush(Color.Yellow);
            Font font = new Font("Times New Roman", 16, FontStyle.Bold);
            redPen.Width = 5;

            using (Graphics graphic = Graphics.FromImage(currentImage))
            {

                graphic.DrawRectangle(redPen, new Rectangle(matchX, matchY, rectWidth, rectHeight));
                graphic.DrawString($"{markerId}", font, brush, matchX - 10, matchY - 10);
            }
            MemoryStream memoryStream = new MemoryStream();
            currentImage.Save(memoryStream, ImageFormat.Png);
            obj.pictureBox1.BeginInvoke((MethodInvoker)delegate { obj.pictureBox1.Image = currentImage; });

        }

    }
}
