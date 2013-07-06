using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimalCrossingQR
{
    public partial class PatternEditor : UserControl
    {
        private bool showGrid = false;
        public bool ShowGrid { get { return showGrid; } set { showGrid = value; Refresh(); } }

        public bool DrawingEnabled { get; set; }

        public byte LeftColor { get; set; }
        public byte RightColor { get; set; }

        private AC.Pattern pattern;

        private byte[,] pixels;
        private AC.Palette palette;
        private Brush[] brushes;

        private const int PixelSize = 9;
        private readonly Pen GridPen = new Pen(Color.FromArgb(156, 154, 156));

        public PatternEditor()
        {
            DrawingEnabled = true;
            LeftColor = 0;
            RightColor = 1;

            pixels = new byte[AC.Pattern.Width, AC.Pattern.Height];
            ClearPattern();

            brushes = AC.Palette.ColorPalette
                .Select(c => new SolidBrush(Color.FromArgb(c.Red, c.Green, c.Blue)))
                .ToArray();

            InitializeComponent();
        }

        public void ClearPattern()
        {
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                    pixels[i, j] = 12;

            palette = new AC.Palette();
        }

        public void LoadPattern(AC.Pattern pattern)
        {
            this.pattern = pattern;

            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                    pixels[i, j] = pattern.Data[i, j];

            palette = new AC.Palette();
            Array.Copy(pattern.ColorPalette.Colors, palette.Colors, pattern.ColorPalette.Colors.Length);

            Refresh();
        }

        public AC.Pattern GetPattern()
        {
            return null;
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

        private void DrawPattern(Graphics graphics)
        {
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                    graphics.FillRectangle(brushes[AC.Palette.GetColorIndexByCode(palette.Colors[pixels[i, j]])], i * PixelSize, j * PixelSize, PixelSize, PixelSize);
        }

        private void DrawGrid(Graphics graphics)
        {
            for (int i = 0; i < pixels.GetLength(0) + 1; i++)
                graphics.DrawLine(GridPen, PixelSize * i, 0, PixelSize * i, pixels.GetLength(0) * PixelSize);
            for (int i = 0; i < pixels.GetLength(1) + 1; i++)
                graphics.DrawLine(GridPen, 0, PixelSize * i, pixels.GetLength(1) * PixelSize, PixelSize * i);
        }

        private void PatternEditor_Paint(object sender, PaintEventArgs e)
        {
            DrawPattern(e.Graphics);

            if (ShowGrid)
                DrawGrid(e.Graphics);
        }

        private Point GetPixelAt(int x, int y)
        {
            return new Point(x / PixelSize, y / PixelSize);
        }

        private void DrawPoint(Point point, byte color)
        {
            if (new Rectangle(0, 0, 32, 32).Contains(point))
            {
                pixels[point.X, point.Y] = color;

                Invalidate();
            }
        }

        private void PatternEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (!DrawingEnabled)
                return;

            Point point = GetPixelAt(e.X, e.Y);
            byte color = e.Button == MouseButtons.Left ? LeftColor : RightColor;
            DrawPoint(point, color);
        }

        private void PatternEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DrawingEnabled)
                return;

            if (!(e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
                return;

            Point point = GetPixelAt(e.X, e.Y);
            byte color = e.Button == MouseButtons.Left ? LeftColor : RightColor;
            DrawPoint(point, color);
        }
    }
}
