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
using System.IO;
using System.Drawing.Imaging;

namespace Aruco_Marker_Detecter
{
    public partial class MarkerGenerator : MetroForm
    {
        public MarkerGenerator()
        {
            InitializeComponent();
        }

        private void Marker_Id_Load(object sender, EventArgs e)
        {

        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            GenerateTheMarker();
            this.Close();
        }

        #region Handy Events
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Backspace)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = !Char.IsDigit(e.KeyChar);
            }
        }

        private void txtMarkSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Backspace)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = !Char.IsDigit(e.KeyChar);
            }
        }

        private void txtPadding_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Backspace)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = !Char.IsDigit(e.KeyChar);
            }
        }

        private void MarkerId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
                btnClick_Click(this, EventArgs.Empty);
        }
        #endregion

        #region Generating Marker
        public void GenerateTheMarker()
        {

            int markerId = int.Parse(txtId.Text);
            int markerSize = int.Parse(txtMarkSize.Text);
            int paddingSize = int.Parse(txtPadding.Text);

            string binaryString = Convert.ToString(markerId, 2);
            char[] binaryArray = binaryString.ToCharArray();
            int extraBits = 10 - binaryArray.Count();

            char[] finalArray = new char[10];
            int k = 0;
            for (int i = 0; i < 10; i++)
            {
                if (i < extraBits)
                {
                    finalArray[i] = '0';
                }
                else
                {
                    finalArray[i] = binaryArray[k];
                    k++;
                }
            }
            char[,] ArucoArray = new char[5, 5];
            int n = 0, m = 1, l = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; i <= 5; j++)
                {
                    ArucoArray[n, m] = finalArray[l];
                    if (ArucoArray[n, m] == '0')
                    {
                        ArucoArray[n, m - 1] = '1';
                    }
                    else
                    {
                        ArucoArray[n, m - 1] = '0';
                    }

                    ArucoArray[n, m + 2] = finalArray[l + 1];
                    ArucoArray[n, m + 1] = ArucoArray[n, m + 2];
                    if (ArucoArray[n, m] == ArucoArray[n, m + 2])
                    {
                        ArucoArray[n, m + 3] = '0';
                    }
                    else
                    {
                        ArucoArray[n, m + 3] = '1';
                    }
                    break;

                }

                l += 2;
                n++;
                m = 1;

            }

            Bitmap img = new Bitmap(markerSize, markerSize);
            Brush blackBrush = new SolidBrush(Color.Black);
            Brush whiteBrush = new SolidBrush(Color.White);

            using (Graphics graph = Graphics.FromImage(img))
            {
                graph.FillRectangle(blackBrush, new Rectangle(0, 0, markerSize, markerSize));
                int x = 0;
                int y = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (ArucoArray[i, j] == '1')
                        {
                            graph.FillRectangle(whiteBrush, new Rectangle(x + paddingSize, y + paddingSize, markerSize / 8, markerSize / 8));
                            x += markerSize / 8;
                        }
                        else if (ArucoArray[i, j] == '0')
                        {
                            graph.FillRectangle(blackBrush, new Rectangle(x + paddingSize, y + paddingSize, markerSize / 8, markerSize / 18));
                            x += markerSize / 8;
                        }
                    }
                    x = 0;
                    y += markerSize / 8;
                }
            }
            SaveMarker(img, markerId);
        }
        #endregion

        private void SaveMarker(Bitmap img, int markerId)
        {
            DirectoryInfo drInfo = new DirectoryInfo(MainForm.DirectoryPath);
            if (!drInfo.Exists)
            {
                Directory.CreateDirectory(MainForm.DirectoryPath);
            }

            string filePath = Path.Combine(MainForm.DirectoryPath, $"{markerId.ToString("d")}.png");
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                img.Save(fileStream, ImageFormat.Png);
            }
        }
    }
}
