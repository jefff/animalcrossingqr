using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AnimalCrossingQR
{
    public class Pattern
    {
        public const int Width = 32;
        public const int Height = 32;

        public string Title { get; set; }
        public User Author { get; set; }

        PatternType Type { get; set; }

        public Palette ColorPalette { get; set; }
        public byte[,] Data { get; set; }

        public Pattern()
        {
            Data = new byte[Width, Height];
        }

        public Pattern(byte[] rawData)
        {

        }

        public Pattern(BinaryReader binaryReader)
            : this()
        {
            NibbleReader nibbleReader = new NibbleReader(binaryReader);

            byte type = nibbleReader.ReadByte();
            if (type != 0x40)
                throw new NotImplementedException();

            int size = nibbleReader.ReadByte();
            size = (size << 4) | nibbleReader.ReadNibble();
            if (size != 0x26C)
                throw new InvalidDataException("Size is invalid.");

            Title = nibbleReader.ReadString(42);
            Author = new User(nibbleReader);

            ColorPalette = new Palette(nibbleReader);

            nibbleReader.ReadByte(); // Unknown
            nibbleReader.ReadByte(); // Unknown, 0x0A
            Type = (PatternType)nibbleReader.ReadByte();
            nibbleReader.ReadByte(); // Unknown, 0x00
            nibbleReader.ReadByte(); // Unknown, 0x00

            for (int j = 0; j < Data.GetLength(1); j++)
                for (int i = 0; i < Data.GetLength(0); i += 2)
                {
                    Data[i + 1, j] = nibbleReader.ReadNibble();
                    Data[i, j] = nibbleReader.ReadNibble();
                }
        }

        public Color GetPixel(int x, int y)
        {
            return ColorPalette.GetColor(Data[x, y]);
        }
    }

    public enum PatternType : byte
    {
        LongOnePiece = 0,
        ShortOnePiece = 1,
        NoOnePiece = 2,

        LongSleeveShirt = 3,
        ShortSleeveShirt = 4,
        NoSleeveShirt = 5,

        HornHat = 6,
        Hat = 7,

        Comic = 8,
        Normal = 9,
    }
}
