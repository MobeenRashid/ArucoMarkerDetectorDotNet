using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Drawing.Imaging;
using System.IO;
using AForge.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading;

namespace Aruco_Marker_Detecter
{
    public partial class MainForm : MetroForm
    {  
        public static string DirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),"Aruco Markers");  
        public static DataTable dataTable = new DataTable();
        public MainForm()
        {
            InitializeComponent();
        }

        string selectedImagePath = String.Empty;

        #region FormLoad
        private void Form1_Load(object sender, EventArgs e)
        {
          
            txtProgress.Visible = false;
            metroProgressSpinner1.Visible = false;

            dataTable.Columns.Add("Id", typeof(string));
            metroGrid1.DataSource = dataTable;


            DirectoryInfo drInfo = new DirectoryInfo(DirectoryPath);

            if (drInfo.Exists)
            {
                if (drInfo.GetFiles().Count() > 0)
                {
                    markerTip.Visible = true;
                    directoryLink.Visible = true;
                }
            }
            else
            {
                markerTip.Visible = false;
                directoryLink.Visible = false;
            }
        }
        #endregion

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {   
                MarkerGenerator mkId = new MarkerGenerator();
                mkId.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nClick the link for help {ex.HelpLink}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void directoryLink_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", DirectoryPath);
        }


        private void btnChooseImageClick(object sender, EventArgs e)
        {
            fileDialog.FileName = "";
            fileDialog.Title = "Select Image";
            fileDialog.Filter = "All Images |*.png; *jpg; *bmp";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName.ToString() != "")
                {
                    selectedImagePath = fileDialog.FileName.ToString();
                }
                
                pictureBox1.Image = System.Drawing.Image.FromFile(selectedImagePath);
                txtImagePath.Text = selectedImagePath;
            }
        }

        private void btnAnalyse_Click(object sender, EventArgs e)
        {
            MainForm.dataTable.Clear();
            Bitmap choosedImage = new Bitmap(selectedImagePath);
            ImageAnalyzer imgAnalyzer = new ImageAnalyzer();
           
            txtProgress.Visible = true;
            metroProgressSpinner1.Visible = true;

            Bitmap blackNWhiteImage = ConvertToBlackAndWhite(choosedImage);
            Bitmap imgFixedPixels = blackNWhiteImage.Clone(new Rectangle(0, 0, blackNWhiteImage.Width, blackNWhiteImage.Height), PixelFormat.Format24bppRgb);
        
            Task.Run(() => { imgAnalyzer.StartAnalysis(this,imgFixedPixels); });  
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
