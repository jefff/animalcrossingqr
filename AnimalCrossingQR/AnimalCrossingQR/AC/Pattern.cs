using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AnimalCrossingQR.AC
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
            : this()
        {
            LoadFromBytes(rawData);
        }

        public Pattern(Image image)
            : this()
        {
            Bitmap resizedImage = new Bitmap(image, new Size(Width, Height));

            BitmapData bitmapData = resizedImage.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            byte[] imagePixelData = new byte[Math.Abs(bitmapData.Stride) * bitmapData.Height];
            Marshal.Copy(bitmapData.Scan0, imagePixelData, 0, imagePixelData.Length);
            resizedImage.UnlockBits(bitmapData);

            LoadFromPixelData(imagePixelData);
        }

        private void LoadFromPixelData(byte[] data)
        {
            Title = "Untitled";
            Author = new User("Someone", "Nowhere", new byte[] { 0, 0, 0, 0, 0, 0 });

            Color[,] sourceImage = new Color[Width, Height];
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    sourceImage[i, j] = new Color(data[(j * Height + i) * 3 + 0], data[(j * Height + i) * 3 + 1], data[(j * Height + i) * 3 + 2]);

            ColorPalette = new Palette();

            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                {

                }
        }

        private void LoadFromBytes(byte[] data)
        {
            MemoryStream memoryStream = new MemoryStream(data);
            LoadFromStream(memoryStream);
            memoryStream.Close();
        }

        private void LoadFromStream(Stream stream)
        {
            BinaryReader binaryReader = new BinaryReader(stream);
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
