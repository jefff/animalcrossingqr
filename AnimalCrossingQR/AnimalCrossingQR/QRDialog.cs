using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimalCrossingQR
{
    public partial class QRDialog : Form
    {
        AC.Pattern pattern;
        Image qrImage;

        public QRDialog(AC.Pattern pattern)
        {
            this.pattern = pattern;
            qrImage = CreateQRCode(pattern);            

            InitializeComponent();
        }

        private void QRDialog_Load(object sender, EventArgs e)
        {
            qrBox.Image = qrImage;
        }

        private Image CreateQRCode(AC.Pattern pattern)
        {
            const int scale = 4;

            ZXing.BarcodeWriter writer = new ZXing.BarcodeWriter();
            writer.Format = ZXing.BarcodeFormat.QR_CODE;

            string data = System.Text.UTF8Encoding.Default.GetString(pattern.GetRawData());
            ZXing.Common.BitMatrix matrix = writer.Encode(data);

            Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);

            // This is probably better done with LockBits. Meh.
            for (int x = 0; x < matrix.Height; x++)
                for (int y = 0; y < matrix.Width; y++)
                {
                    Color pixel = matrix[x, y] ? Color.Black : Color.White;
                    for (int i = 0; i < scale; i++)
                        for (int j = 0; j < scale; j++)
                            result.SetPixel(x * scale + i, y * scale + j, pixel);
                }
            
            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
