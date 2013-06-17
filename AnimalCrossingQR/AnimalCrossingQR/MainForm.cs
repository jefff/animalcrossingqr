using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimalCrossingQR
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private System.Drawing.Color FromPaletteColor(Color color)
        {
            return System.Drawing.Color.FromArgb(color.Red, color.Green, color.Blue);
        }

        private Image RenderPattern(Pattern pattern, int scale)
        {
            Bitmap bitmap = new Bitmap(Pattern.Width * scale, Pattern.Height * scale);
            
            for (int i = 0; i < Pattern.Width; i++)
                for (int j = 0; j < Pattern.Height; j++)
                {
                    Color c = pattern.GetPixel(i, j);

                    for (int x = 0; x < scale; x++)
                        for (int y = 0; y < scale; y++)
                            bitmap.SetPixel(scale * i + x, scale * j + y, FromPaletteColor(c));
                }

            return bitmap;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
