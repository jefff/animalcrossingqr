using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AnimalCrossingQR
{
    public partial class QRDialog : Form
    {
        AC.Pattern pattern;
        Image qrImage;

        public QRDialog(AC.Pattern pattern)
        {
            this.pattern = pattern;
            qrImage = CreateQRCode(pattern, 3);            

            InitializeComponent();
        }

        private void QRDialog_Load(object sender, EventArgs e)
        {
            qrBox.Image = qrImage;
        }

        private Image CreateQRCode(AC.Pattern pattern, int scale)
        {
            ZXing.BarcodeWriter writer = new ZXing.BarcodeWriter();
            writer.Format = ZXing.BarcodeFormat.QR_CODE;

            string data = new string(pattern.GetRawData().Select(b => Convert.ToChar(b)).ToArray());
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
            sfd.FileName = pattern.Title + ".png";

            if (sfd.ShowDialog() == DialogResult.OK)
                CreateOutputImage().Save(sfd.FileName);
        }

        private Image CreateOutputImage()
        {
            Image outputImage = new Bitmap(400, 240);
            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.Clear(Color.White);

                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                Font font = new System.Drawing.Font("Arial", 18, FontStyle.Regular);
                graphics.DrawString(pattern.Title, font, Brushes.Black, 195, 18, sf);

                graphics.DrawImage(CreateQRCode(pattern, 2), new Point(187, 35));

                graphics.DrawImage(RenderPattern(pattern, 4), 37, 69);
            }

            return outputImage;
        }

        private Image RenderPattern(AC.Pattern pattern, int scale)
        {
            Bitmap bitmap = new Bitmap(AC.Pattern.Width * scale, AC.Pattern.Height * scale);

            for (int i = 0; i < AC.Pattern.Width; i++)
                for (int j = 0; j < AC.Pattern.Height; j++)
                {
                    AC.Color c = pattern.GetPixel(i, j);

                    for (int x = 0; x < scale; x++)
                        for (int y = 0; y < scale; y++)
                            bitmap.SetPixel(scale * i + x, scale * j + y, FromPaletteColor(c));
                }

            return bitmap;
        }

        private Color FromPaletteColor(AC.Color color)
        {
            return Color.FromArgb(color.Red, color.Green, color.Blue);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                uploadButton.Text = "Uploading...";
                uploadButton.Enabled = false;
                using (WebClient w = new WebClient())
                using (MemoryStream ms = new MemoryStream())
                {
                    Image outputImage = CreateOutputImage();

                    outputImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    var values = new NameValueCollection
                    {
                        { "image", Convert.ToBase64String(ms.ToArray()) }
                    };
                    w.Headers.Add("Authorization", "Client-ID c388ed6b11fecdb");

                    byte[] response = w.UploadValues("https://api.imgur.com/3/image", values);

                    JObject result = (JObject)JsonConvert.DeserializeObject(System.Text.Encoding.ASCII.GetString(response));

                    string link = result["data"]["link"].ToString();
                    linkBox.Text = link;
                    linkBox.Visible = true;
                    goButton.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload failed!\nReason: " + ex.Message);
            }
            finally
            {
                uploadButton.Text = "Upload to Imgur";
                uploadButton.Enabled = true;
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(linkBox.Text);
        }
    }
}
