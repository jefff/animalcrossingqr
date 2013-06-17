using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCrossingQR
{
    public class Palette
    {
        #region Palette
        public static readonly Color[] ColorPalette = new Color[]
        {
            new Color(255, 239, 255),
            new Color(255, 154, 173),
            new Color(239, 85, 156),
            new Color(255, 101, 173),
            new Color(255, 0, 99),
            new Color(189, 69, 115),
            new Color(206, 0, 82),
            new Color(156, 0, 49),
            new Color(82, 32, 49),
            new Color(255, 186, 206),
            new Color(255, 117, 115),
            new Color(222, 48, 16),
            new Color(255, 85, 66),
            new Color(255, 0, 0),
            new Color(206, 101, 99),
            new Color(189, 69, 66),
            new Color(189, 0, 0),
            new Color(140, 32, 33),
            new Color(222, 207, 189),
            new Color(255, 207, 99),
            new Color(222, 101, 33),
            new Color(255, 170, 33),
            new Color(255, 101, 0),
            new Color(189, 138, 82),
            new Color(222, 69, 0),
            new Color(189, 69, 0),
            new Color(99, 48, 16),
            new Color(255, 239, 222),
            new Color(255, 223, 206),
            new Color(255, 207, 173),
            new Color(255, 186, 140),
            new Color(255, 170, 140),
            new Color(222, 138, 99),
            new Color(189, 101, 66),
            new Color(156, 85, 49),
            new Color(140, 69, 33),
            new Color(255, 207, 255),
            new Color(239, 138, 255),
            new Color(206, 101, 222),
            new Color(189, 138, 206),
            new Color(206, 0, 255),
            new Color(156, 101, 156),
            new Color(140, 0, 173),
            new Color(82, 0, 115),
            new Color(49, 0, 66),
            new Color(255, 186, 255),
            new Color(255, 154, 255),
            new Color(222, 32, 189),
            new Color(255, 85, 239),
            new Color(255, 0, 206),
            new Color(140, 85, 115),
            new Color(189, 0, 156),
            new Color(140, 0, 99),
            new Color(82, 0, 66),
            new Color(222, 186, 156),
            new Color(206, 170, 115),
            new Color(115, 69, 49),
            new Color(173, 117, 66),
            new Color(156, 48, 0),
            new Color(115, 48, 33),
            new Color(82, 32, 0),
            new Color(49, 16, 0),
            new Color(33, 16, 0),
            new Color(255, 255, 206),
            new Color(255, 255, 115),
            new Color(222, 223, 33),
            new Color(255, 255, 0),
            new Color(255, 223, 0),
            new Color(206, 170, 0),
            new Color(156, 154, 0),
            new Color(140, 117, 0),
            new Color(82, 85, 0),
            new Color(222, 186, 255),
            new Color(189, 154, 239),
            new Color(99, 48, 206),
            new Color(156, 85, 255),
            new Color(99, 0, 255),
            new Color(82, 69, 140),
            new Color(66, 0, 156),
            new Color(33, 0, 99),
            new Color(33, 16, 49),
            new Color(189, 186, 255),
            new Color(140, 154, 255),
            new Color(49, 48, 173),
            new Color(49, 85, 239),
            new Color(0, 0, 255),
            new Color(49, 48, 140),
            new Color(0, 0, 173),
            new Color(16, 16, 99),
            new Color(0, 0, 33),
            new Color(156, 239, 189),
            new Color(99, 207, 115),
            new Color(33, 101, 16),
            new Color(66, 170, 49),
            new Color(0, 138, 49),
            new Color(82, 117, 82),
            new Color(33, 85, 0),
            new Color(16, 48, 33),
            new Color(0, 32, 16),
            new Color(222, 255, 189),
            new Color(206, 255, 140),
            new Color(140, 170, 82),
            new Color(173, 223, 140),
            new Color(140, 255, 0),
            new Color(173, 186, 156),
            new Color(99, 186, 0),
            new Color(82, 154, 0),
            new Color(49, 101, 0),
            new Color(189, 223, 255),
            new Color(115, 207, 255),
            new Color(49, 85, 156),
            new Color(99, 154, 255),
            new Color(16, 117, 255),
            new Color(66, 117, 173),
            new Color(33, 69, 115),
            new Color(0, 32, 115),
            new Color(0, 16, 66),
            new Color(173, 255, 255),
            new Color(82, 255, 255),
            new Color(0, 138, 189),
            new Color(82, 186, 206),
            new Color(0, 207, 255),
            new Color(66, 154, 173),
            new Color(0, 101, 140),
            new Color(0, 69, 82),
            new Color(0, 32, 49),
            new Color(206, 255, 239),
            new Color(173, 239, 222),
            new Color(49, 207, 173),
            new Color(82, 239, 189),
            new Color(0, 255, 206),
            new Color(115, 170, 173),
            new Color(0, 170, 156),
            new Color(0, 138, 115),
            new Color(0, 69, 49),
            new Color(173, 255, 173),
            new Color(115, 255, 115),
            new Color(99, 223, 66),
            new Color(0, 255, 0),
            new Color(33, 223, 33),
            new Color(82, 186, 82),
            new Color(0, 186, 0),
            new Color(0, 138, 0),
            new Color(33, 69, 33),
            new Color(255, 255, 255),
            new Color(239, 239, 239),
            new Color(222, 223, 222),
            new Color(206, 207, 206),
            new Color(189, 186, 189),
            new Color(173, 170, 173),
            new Color(156, 154, 156),
            new Color(140, 138, 140),
            new Color(115, 117, 115),
            new Color(99, 101, 99),
            new Color(82, 85, 82),
            new Color(66, 69, 66),
            new Color(49, 48, 49),
            new Color(33, 32, 33),
            new Color(0, 0, 0)
        };
        #endregion

        public byte[] Colors { get; set; }

        public Palette()
        {
            Colors = new byte[15];
        }

        public Palette(NibbleReader nibbleReader)
            : this()
        {
            for (int i = 0; i < 15; i++)
                Colors[i] = nibbleReader.ReadByte();
        }

        public Color GetColor(int index)
        {
            return GetColorByCode(Colors[index]);
        }

        public static Color GetColorByCode(byte code)
        {
            return ColorPalette[GetColorIndex(code)];
        }

        public static Color GetNearestColorCode(Color color)
        {
            return ColorPalette.Aggregate((a, b) => Color.DistanceSquared(a, color) < Color.DistanceSquared(b, color) ? a : b);
        }

        private static byte GetColorCode(int index)
        {
            if (index >= 144)
                return (byte)(((index - 144) << 4) | 0x0F);

            return (byte)(((index / 9) << 4) | (index % 9));
        }

        private static int GetColorIndex(byte code)
        {
            // Grayscale colors
            if ((code & 0x0F) == 0x0F)
                return 144 + (code >> 4);

            // Other colors
            return ((code & 0xF0) >> 4) * 9 + (code & 0x0F);
        }
    }
}
