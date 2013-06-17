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

        private Brush[] paletteBrushes;

        private const int ColorBoxBorder = 1;
        private const int ColorBoxSize = 20;
        private const int ColorBoxesLeftBorder = 22;
        private const int NineBoxSpacing = 10;
        private const int FirstGrayscaleIndex = 144;

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
                graphics.FillRectangle(paletteBrushes[FirstGrayscaleIndex + i],
                    new Rectangle(
                        ColorBoxBorder + (ColorBoxSize + ColorBoxBorder) * i,
                        4 * (ColorBoxSize * 3 + NineBoxSpacing),
                        ColorBoxSize,
                        ColorBoxSize));
        }

        private void DrawNineBox(Graphics graphics, int x, int y, int colorIndex)
        {
            graphics.FillRectangle(Brushes.Gray, new Rectangle(x - ColorBoxBorder, y - ColorBoxBorder, ColorBoxBorder * 4 + ColorBoxSize * 3, ColorBoxBorder * 4 + ColorBoxSize * 3));

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    graphics.FillRectangle(
                        paletteBrushes[colorIndex + 3 * j + i],
                        new Rectangle(
                            x + (ColorBoxSize + ColorBoxBorder) * i,
                            y + (ColorBoxSize + ColorBoxBorder) * j,
                            ColorBoxSize,
                            ColorBoxSize));
        }

        private void colorPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawFullColorPalette(e.Graphics);
        }

        private void ColorDialog_Load(object sender, EventArgs e)
        {
            paletteBrushes = Palette.ColorPalette
                .Select(c => new SolidBrush(System.Drawing.Color.FromArgb(c.Red, c.Green, c.Blue)))
                .ToArray();
        }
    }
}
