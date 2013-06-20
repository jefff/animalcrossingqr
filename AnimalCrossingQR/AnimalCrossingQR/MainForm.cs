using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnimalCrossingQR.Properties;

namespace AnimalCrossingQR
{
    public partial class MainForm : Form
    {
        private const string SetDefaultMessage = "Do you want to make the current author the default?";
        private const string UniqueIDHelpMessage = "To be considered the 'owner' of a particular pattern (and for it" +
            " to be editable in game), your name, town name and unique ID must match. The easiest way to determine" +
            " your unique ID is to open a QR code of a pattern you created. After doing so, press 'Save as default'" +
            " so that you can use it for other patterns and gain in-game ownership.";

        public MainForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void LoadSettings()
        {
            authorNameText.Text = Settings.Default["AuthorName"].ToString();
            authorTownText.Text = Settings.Default["AuthorTown"].ToString();
            authorUniqueIDText.Text = Settings.Default["AuthorUniqueID"].ToString();
        }

        private void SaveSettings()
        {
            Settings.Default["AuthorName"] = authorNameText.Text;
            Settings.Default["AuthorTown"] = authorTownText.Text;
            Settings.Default["AuthorUniqueID"] = authorUniqueIDText.Text;
            Settings.Default.Save();
        }

        private Color FromPaletteColor(AC.Color color)
        {
            return Color.FromArgb(color.Red, color.Green, color.Blue);
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void blankToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fromImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream = new FileStream(imageOpenFileDialog.FileName, FileMode.Open);
                Image image = Image.FromStream(fileStream);
                fileStream.Close();

                ImageSelectDialog imageSelectDialog = new ImageSelectDialog(image);
                if (imageSelectDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadPattern(new AC.Pattern(image));
                }
            }
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
            if (imageOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream = new FileStream(imageOpenFileDialog.FileName, FileMode.Open);
                Bitmap bitmap = (Bitmap)Bitmap.FromStream(fileStream);
                fileStream.Close();

                LoadFromQR(bitmap);
            }
        }

        private void LoadFromQR(Bitmap bitmap)
        {
            ZXing.BarcodeReader reader = new ZXing.BarcodeReader();
            reader.PossibleFormats = new[] { ZXing.BarcodeFormat.QR_CODE };
            ZXing.Result result = reader.Decode(bitmap);

            if (result != null)
            {
                AC.Pattern pattern = new AC.Pattern(result.RawBytes);
                LoadPattern(pattern);
            }
        }

        private AC.Pattern lastPattern;

        private void LoadPattern(AC.Pattern pattern)
        {
            lastPattern = pattern;

            titleText.Text = pattern.Title;
            authorNameText.Text = pattern.Author.Name;
            authorTownText.Text = pattern.Author.Town;
            authorUniqueIDText.Text = string.Join(":", pattern.Author.UniqueID.Select(b => b.ToString("X2")));

            for (int i = 0; i < pattern.ColorPalette.Colors.Length; i++)
                paletteControl.Items[i] = AC.Palette.GetColorIndexByCode(pattern.ColorPalette.Colors[i]);

            patternPanel.BackgroundImageLayout = ImageLayout.None;
            patternPanel.BackgroundImage = RenderPattern(pattern, 8);
        }

        private void loadDefaultButton_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void setDefaultButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(SetDefaultMessage, Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                SaveSettings();
        }

        private void helpBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UniqueIDHelpMessage, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
 
        }
    }
}
