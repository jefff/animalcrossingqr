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
    public partial class QRSelectDialog : Form
    {
        public int SelectedIndex { get; private set; }

        Image image;
        Rectangle[] rectangles;        

        Pen selectedPen = new Pen(Color.Yellow, 5);
        Pen unselectedPen = new Pen(Color.Red, 5);

        Image viewImage;
        Graphics viewGraphics;

        public QRSelectDialog(Image image, Rectangle[] rectangles)
        {
            this.image = image;
            this.rectangles = rectangles;
            SelectedIndex = 0;

            InitializeComponent();
        }

        private void QRSelectDialog_Load(object sender, EventArgs e)
        {
            viewImage = new Bitmap(image.Width, image.Height);
            viewGraphics = Graphics.FromImage(viewImage);

            pictureBox.Image = viewImage;
            pictureBox.Width = viewImage.Width;
            pictureBox.Height = viewImage.Height;

            RedrawViewImage();
        }

        private void RedrawViewImage()
        {
            viewGraphics.Clear(Color.Transparent);
            viewGraphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));

            for (int i = 0; i < rectangles.Length; i++)
                viewGraphics.DrawRectangle(i == SelectedIndex ? selectedPen : unselectedPen, rectangles[i]);

            pictureBox.Refresh();
        }

        private int? GetRectangleAt(Point location)
        {
            for (int i = 0; i < rectangles.Length; i++)
            {
                if (rectangles[i].Contains(location.X, location.Y))
                    return i;
            }

            return null;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            int? rectangleAtMouse = GetRectangleAt(e.Location);
            if (rectangleAtMouse != null)
                SelectedIndex = rectangleAtMouse.Value;

            RedrawViewImage();
        }

        private void imagePanel_MouseEnter(object sender, EventArgs e)
        {
            imagePanel.Focus();
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            imagePanel.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
