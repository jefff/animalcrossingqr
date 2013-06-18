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

        private void blankToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editColorsButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog(paletteControl.Items);
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < paletteControl.Items.Length; i++)
                    paletteControl.Items[i] = colorDialog.Items[i];
            }
        }

        private void fromQRCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream = new FileStream(ofd.FileName, FileMode.Open);
                Bitmap bitmap = (Bitmap)Bitmap.FromStream(fileStream);
                fileStream.Close();

                LoadFromQR(bitmap);
            }
        }

        private void LoadFromQR(Bitmap bitmap)
        {
            ZXing.BarcodeReader reader = new ZXing.BarcodeReader();
            ZXing.Result result = reader.Decode(bitmap);

            if (result != null)
            {
                Pattern pattern = new Pattern(result.RawBytes);
                LoadPattern(pattern);
            }
        }

        private void LoadPattern(Pattern pattern)
        {
            titleText.Text = pattern.Title;
            authorNameText.Text = pattern.Author.Name;
            authorTownText.Text = pattern.Author.Town;
            authorUniqueIDText.Text = string.Join(":", pattern.Author.UniqueID.Select(b => b.ToString("X2")));

            for (int i = 0; i < pattern.ColorPalette.Colors.Length; i++)
                paletteControl.Items[i] = Palette.GetColorIndexByCode(pattern.ColorPalette.Colors[i]);

            patternPanel.BackgroundImageLayout = ImageLayout.None;
            patternPanel.BackgroundImage = RenderPattern(pattern, 8);
        }
    }
}
