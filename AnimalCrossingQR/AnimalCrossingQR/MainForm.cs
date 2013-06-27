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
            " so that you can use it for other patterns and gain in-game ownership of any QR codes you create.";

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

            authorUniqueIDText.Text = string.Join(":", authorUniqueIDText.Text
                .Split(':')
                .Select(s => s.Trim().PadLeft(2, '0')));
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
                using (FileStream fileStream = new FileStream(imageOpenFileDialog.FileName, FileMode.Open))
                using (Image image = Image.FromStream(fileStream))
                    LoadPattern(new AC.Pattern(image));

                LoadSettings();
            }
        }

        private void fromImageURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (URLDialog urlDialog = new URLDialog())
            if (urlDialog.ShowDialog() == DialogResult.OK)
            {
                LoadPattern(new AC.Pattern(urlDialog.ResultImage));
                LoadSettings();
            }
        }

        private void editColorsButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog(paletteControl.Items))
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < paletteControl.Items.Length; i++)
                    paletteControl.Items[i] = colorDialog.Items[i];

                if (currentPattern != null)
                {
                    for (int i = 0; i < paletteControl.Items.Length; i++)
                        currentPattern.ColorPalette.SetColor(i, AC.Palette.ColorPalette[paletteControl.Items[i]]);

                    LoadPattern(currentPattern);
                }
            }
        }

        private void fromQRCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(imageOpenFileDialog.FileName, FileMode.Open))
                using (Bitmap bitmap = (Bitmap)Bitmap.FromStream(fileStream))
                    LoadFromQR(bitmap);
            }
        }

        private void fromQRCodeURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (URLDialog urlDialog = new URLDialog())
            if (urlDialog.ShowDialog() == DialogResult.OK)
                LoadFromQR(urlDialog.ResultImage);
        }

        private void LoadFromQR(Bitmap bitmap)
        {
            ZXing.BarcodeReader reader = new ZXing.BarcodeReader();
            reader.PossibleFormats = new[] { ZXing.BarcodeFormat.QR_CODE };
            ZXing.Result result = reader.Decode(bitmap);


            if (result != null)
            {
                try
                {
                    AC.Pattern pattern = AC.Pattern.CreateFromRawData(result.RawBytes);
                    LoadPattern(pattern);
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show("This type of pattern is currently not supported.", Text);
                }
            }
            else
            {
                MessageBox.Show("A valid QR code was not found in the selected image.", Text);
            }
        }

        private AC.Pattern currentPattern;

        private void LoadPattern(AC.Pattern pattern)
        {
            currentPattern = pattern;

            titleText.Text = pattern.Title;
            authorNameText.Text = pattern.Author.Name;
            authorTownText.Text = pattern.Author.Town;
            authorUniqueIDText.Text = string.Join(":", pattern.Author.UniqueID.Select(b => b.ToString("X2")));

            for (int i = 0; i < pattern.ColorPalette.Colors.Length; i++)
                paletteControl.Items[i] = AC.Palette.GetColorIndexByCode(pattern.ColorPalette.Colors[i]);

            patternPanel.BackgroundImageLayout = ImageLayout.None;
            patternPanel.BackgroundImage = RenderPattern(pattern, 8);

            titleText.Enabled = true;
            editColorsButton.Enabled = true;
            createQRButton.Enabled = true;
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

        private void SavePattern()
        {
            authorUniqueIDText.Text = new string(authorUniqueIDText.Text.Where(c => char.IsNumber(c) || c == ':' || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')).ToArray());

            currentPattern.Title = titleText.Text;
            currentPattern.Author.Name = authorNameText.Text;
            currentPattern.Author.Town = authorTownText.Text;
            currentPattern.Author.UniqueID =
                authorUniqueIDText.Text
                .Split(':')
                .Select(s => Convert.ToByte(s.Trim().PadLeft(2, '0'), 16))
                .ToArray();
        }

        private void createQRButton_Click(object sender, EventArgs e)
        {
            if (currentPattern == null)
            {
                MessageBox.Show("There is no pattern currently active.", Text);
                return;
            }

            SavePattern();
            using (QRDialog qrDialog = new QRDialog(currentPattern))
                qrDialog.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (imageOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile(imageOpenFileDialog.FileName);

                for (int i = 0; i < bitmap.Width; i++)
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        Color c = bitmap.GetPixel(i, j);
                        AC.Color nc = AC.Palette.GetNearestColor(new AC.Color(c.R, c.G, c.B));
                        bitmap.SetPixel(i, j, Color.FromArgb(nc.Red, nc.Green, nc.Blue));
                    }

                bitmap.Save(imageOpenFileDialog.FileName + ".png");
            }
        }

        private void authorUniqueIDText_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(authorUniqueIDText.Text, @"\A\b[0-9a-fA-F:]+\b\Z"))
            {
                authorUniqueIDText.Text = new string(authorUniqueIDText.Text.Where(c => char.IsNumber(c) || c == ':' || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')).ToArray());
            }
        }
    }
}
