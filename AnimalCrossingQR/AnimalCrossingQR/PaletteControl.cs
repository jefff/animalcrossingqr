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
        public int SelectedIndex { get { return DisableSelect ? -1 : selectedIndex; } set { selectedIndex = value; Invalidate(); } }

        public bool DisableSelect { get; set; }

        private Brush[] paletteBrushes;

        public PaletteControl()
        {
            SelectedIndex = -1;
            DisableSelect = false;

            Items = new PaletteList(15, Invalidate);
            for (int i = 0; i < Items.Length; i++)
                Items[i] = AC.Palette.GetColorIndexByCode(AC.Palette.DefaultColorCodes[i]);

            paletteBrushes = AC.Palette.ColorPalette
                .Select(c => new SolidBrush(System.Drawing.Color.FromArgb(c.Red, c.Green, c.Blue)))
                .ToArray();

            InitializeComponent();
        }

        private void Palette_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                e.Graphics.FillRectangle(i == SelectedIndex ? Brushes.Gold : Brushes.Black, new Rectangle(5 - 2, 5 - 2 + 20 * i, 50 + 4, 15 + 4));
                e.Graphics.FillRectangle(paletteBrushes[Items[i]], new Rectangle(5, 5 + 20 * i, 50, 15));
            }
        }

        private void PaletteControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 5 && e.X < 55)
                SelectedIndex = (e.Y - 5) / 20;
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
