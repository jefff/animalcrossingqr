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
    public partial class PaletteControl : UserControl
    {
        public PaletteList Items { get; private set; }
        public int SelectedItem
        {
            get { return SelectedIndex == -1 ? -1 : Items[SelectedIndex]; }
            set { if (SelectedIndex != -1) Items[SelectedIndex] = value; }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return (Selection == SelectionType.Disabled) ? -1 : selectedIndex;
            }
            set
            {
                selectedIndex = value;
                Invalidate();
                OnSelectedIndexChanged();
            }
        }

        private int secondarySelectedIndex;
        public int SecondarySelectedIndex
        {
            get
            {
                return (Selection != SelectionType.DoubleSelect) ? -1 : secondarySelectedIndex;
            }
            set
            {
                secondarySelectedIndex = value;
                Invalidate();
                OnSecondarySelectedIndexChanged();
            }
        }

        public event EventHandler SelectedIndexChanged;
        public event EventHandler SecondarySelectedIndexChanged;

        public enum SelectionType
        {
            Disabled,
            SingleSelect,
            DoubleSelect,
        }
        public SelectionType Selection { get; set; }

        private Brush[] paletteBrushes;

        private const int LeftBorder = 10;
        private const int TopBorder = 5;
        private const int SelectionBorderWidth = 2;
        private const int ColorWidth = 50;
        private const int ColorHeight = 15;
        private const int ColorDistance = 20;

        public PaletteControl()
        {
            SelectedIndex = -1;
            Selection = SelectionType.SingleSelect;

            Items = new PaletteList(15, Invalidate);
            for (int i = 0; i < Items.Length; i++)
                Items[i] = AC.Palette.GetColorIndexByCode(AC.Palette.DefaultColorCodes[i]);

            paletteBrushes = AC.Palette.ColorPalette
                .Select(c => new SolidBrush(System.Drawing.Color.FromArgb(c.Red, c.Green, c.Blue)))
                .ToArray();

            InitializeComponent();
        }

        private void OnSelectedIndexChanged()
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void OnSecondarySelectedIndexChanged()
        {
            if (SecondarySelectedIndexChanged != null)
                SecondarySelectedIndexChanged(this, EventArgs.Empty);
        }

        private static void DrawTriangle(Graphics graphics, Brush brush, int x, int y, bool pointLeft)
        {
            Point[] trianglePoints = new[]
            {
                new Point(x, y),
                new Point(x + ((LeftBorder / 2) * (pointLeft ? 1 : -1)), y - (LeftBorder / 2)),
                new Point(x + ((LeftBorder / 2) * (pointLeft ? 1 : -1)), y + (LeftBorder / 2)),
            };

            graphics.FillPolygon(brush, trianglePoints);
        }

        private void Palette_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Rectangle colorRectangle = new Rectangle(LeftBorder, TopBorder + ColorDistance * i, ColorWidth, ColorHeight);
                Rectangle selectionRectangle = Rectangle.Inflate(colorRectangle, SelectionBorderWidth, SelectionBorderWidth);

                e.Graphics.FillRectangle((Selection == SelectionType.SingleSelect) && (i == SelectedIndex) ? Brushes.Gold : Brushes.Black, selectionRectangle);
                e.Graphics.FillRectangle(paletteBrushes[Items[i]], colorRectangle);

                if (Selection == SelectionType.DoubleSelect)
                {
                    if (i == SelectedIndex)
                        DrawTriangle(e.Graphics, Brushes.Black, LeftBorder / 2, TopBorder + ColorDistance * i + ColorHeight / 2, false);
                    if (i == SecondarySelectedIndex)
                        DrawTriangle(e.Graphics, Brushes.Black, LeftBorder / 2 + LeftBorder + ColorWidth, TopBorder + ColorDistance * i + ColorHeight / 2, true);
                }
            }
        }

        private void PaletteControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > LeftBorder && e.X < LeftBorder + ColorWidth)
            {
                if (e.Button == MouseButtons.Left)
                    SelectedIndex = (e.Y - TopBorder) / ColorDistance;
                else if (e.Button == MouseButtons.Right)
                    SecondarySelectedIndex = (e.Y - TopBorder) / ColorDistance;
            }
        }
    }

    public class PaletteList
    {
        private int[] colors;
        private Action invalidate;

        public int Length { get { return colors.Length; } }
               
        public PaletteList(int size, Action invalidate = null)
        {
            colors = new int[size];
            this.invalidate = invalidate;
        }

        public PaletteList(int[] initial, Action invalidate = null)
            : this(initial.Length, invalidate)
        {
            for (int i = 0; i < initial.Length; i++)
                colors[i] = initial[i];
        }

        private void CallInvalidate()
        {
            if (invalidate != null)
                invalidate();
        }

        public int this[int index]
        {
            get { return colors[index]; }
            set { colors[index] = value; CallInvalidate(); }
        }
    }
}
