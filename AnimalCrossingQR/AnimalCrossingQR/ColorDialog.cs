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
    public partial class ColorDialog : Form
    {
        public ColorDialog()
        {
            InitializeComponent();
        }

        private Brush[] oppositePaletteBrushes;
        private Brush[] paletteBrushes;
        private string[] paletteLabels;

        private int selectedIndex = -1;

        private Font textFont;
        private StringFormat stringFormat;

        private const int ColorBoxBorder = 1;
        private const int ColorBoxSize = 20;
        private const int ColorBoxesLeftBorder = 22;
        private const int NineBoxSpacing = 10;
        private const int FirstGrayscaleIndex = 144;

        private void ColorDialog_Load(object sender, EventArgs e)
        {
            textFont = new System.Drawing.Font("Arial", 8);
            stringFormat = new StringFormat()
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center,
            };

            paletteBrushes = Palette.ColorPalette
                .Select(c => new SolidBrush(System.Drawing.Color.FromArgb(c.Red, c.Green, c.Blue)))
                .ToArray();

            oppositePaletteBrushes = Palette.ColorPalette
                .Select(c => (c.Red * 0.2126) + (c.Green * 0.7152) + (c.Blue * 0.0722) > 128 ? Brushes.Black : Brushes.White)
                .ToArray();

            paletteLabels = new string[Palette.ColorPalette.Length];
            Random r = new Random();
            for (int i = 0; i < 15; i++)
                paletteControl.Items[i] = r.Next(Palette.ColorPalette.Length);
        }

        private void DrawFullColorPalette(Graphics graphics)
        {
            for (int y = 0; y < 4; y++)
                for (int x = 0; x < 4; x++)
                    DrawNineBox(graphics, 
                        x * (ColorBoxSize * 3 + NineBoxSpacing) + ColorBoxesLeftBorder,
                        y * (ColorBoxSize * 3 + NineBoxSpacing) + ColorBoxBorder,
                        (x + 4 * y) * 9);

            graphics.FillRectangle(Brushes.Gray, new Rectangle(0, 4 * (ColorBoxSize * 3 + NineBoxSpacing) - 1, 21 * 15 + 1, 21 + 1));
            for (int i = 0; i < 15; i++)
            {
                Rectangle rect = new Rectangle(
                        ColorBoxBorder + (ColorBoxSize + ColorBoxBorder) * i,
                        4 * (ColorBoxSize * 3 + NineBoxSpacing),
                        ColorBoxSize,
                        ColorBoxSize);

                graphics.FillRectangle(paletteBrushes[FirstGrayscaleIndex + i], rect);
                graphics.DrawString(paletteLabels[FirstGrayscaleIndex + i], textFont, oppositePaletteBrushes[FirstGrayscaleIndex + i], rect, stringFormat);
            }
        }

        private void DrawNineBox(Graphics graphics, int x, int y, int colorIndex)
        {
            graphics.FillRectangle(Brushes.Gray, new Rectangle(x - ColorBoxBorder, y - ColorBoxBorder, ColorBoxBorder * 4 + ColorBoxSize * 3, ColorBoxBorder * 4 + ColorBoxSize * 3));

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Rectangle rect = new Rectangle(
                            x + (ColorBoxSize + ColorBoxBorder) * i,
                            y + (ColorBoxSize + ColorBoxBorder) * j,
                            ColorBoxSize,
                            ColorBoxSize);

                    graphics.FillRectangle(paletteBrushes[colorIndex + 3 * j + i], rect);
                    graphics.DrawString(paletteLabels[colorIndex + 3 * j + i], textFont, oppositePaletteBrushes[colorIndex + 3 * j + i], rect, stringFormat);
                }
        }

        private void UpdateLabels()
        {
            for (int i = 0; i < paletteLabels.Length; i++)
                paletteLabels[i] = "";

            for (int i = 0; i < paletteControl.Items.Length; i++)
                paletteLabels[paletteControl.Items[i]] = (i + 1).ToString();
        }

        private void colorPanel_Paint(object sender, PaintEventArgs e)
        {
            UpdateLabels();
            DrawFullColorPalette(e.Graphics);
        }

        private void palettePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void palettePanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 5 && e.X < 55)
                selectedIndex = (e.Y - 5) / 20;
        }

        private void colorPanel_MouseClick(object sender, MouseEventArgs e)
        {
            int? color = GetColorClick(e.X, e.Y);
            if (color != null)
                paletteControl.SelectedItem = color.Value;

            colorPanel.Invalidate();
        }

        private bool IsInRectangle(Rectangle rect, int pX, int pY)
        {
            return (pX > rect.Left) && (pY > rect.Top) && (pX < rect.Right) && (pY < rect.Bottom);
        }

        private int? GetColorClick(int pX, int pY)
        {
            for (int y = 0; y < 4; y++)
                for (int x = 0; x < 4; x++)
                {
                    int? index = IsInNineBox(
                        x * (ColorBoxSize * 3 + NineBoxSpacing) + ColorBoxesLeftBorder,
                        y * (ColorBoxSize * 3 + NineBoxSpacing) + ColorBoxBorder,
                        pX, pY);

                    if (index != null)
                        return (x + 4 * y) * 9 + index;
                }

            for (int i = 0; i < 15; i++)
            {
                Rectangle rect = new Rectangle(
                        ColorBoxBorder + (ColorBoxSize + ColorBoxBorder) * i,
                        4 * (ColorBoxSize * 3 + NineBoxSpacing),
                        ColorBoxSize,
                        ColorBoxSize);

                if (IsInRectangle(rect, pX, pY))
                    return FirstGrayscaleIndex + i;
            }

            return null;
        }

        private int? IsInNineBox(int x, int y, int pX, int pY)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Rectangle rect = new Rectangle(
                            x + (ColorBoxSize + ColorBoxBorder) * i,
                            y + (ColorBoxSize + ColorBoxBorder) * j,
                            ColorBoxSize,
                            ColorBoxSize);

                    if (IsInRectangle(rect, pX, pY))
                        return 3 * j + i;
                }

            return null;
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
