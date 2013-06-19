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
    public partial class ImageSelectDialog : Form
    {
        Image sourceImage;
        Image resizedSourceImage;

        Image overlayImage;
        Graphics overlayGraphics;

        public ImageSelectDialog(Image image)
        {
            InitializeComponent();

            sourceImage = image;
            double largerDimension = Math.Max(sourceImage.Width, sourceImage.Height);
            double scale = Math.Min(1.0, (pictureBox.Width - 2) / largerDimension);

            resizedSourceImage = new Bitmap(sourceImage, (int)(sourceImage.Width * scale), (int)(sourceImage.Height * scale));
           
            overlayImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            overlayGraphics = Graphics.FromImage(overlayImage);
            overlayGraphics.Clear(Color.Transparent);

            pictureBox.BackgroundImage = resizedSourceImage;
            pictureBox.BackgroundImageLayout = ImageLayout.None;
            pictureBox.Image = overlayImage;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            overlayGraphics.Clear(Color.Transparent);

            overlayGraphics.DrawRectangle(Pens.Black, new Rectangle(1, 1, e.X - 1, e.Y - 1));
            overlayGraphics.DrawRectangle(Pens.White, new Rectangle(0, 0, e.X, e.Y));

            pictureBox.Invalidate();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
