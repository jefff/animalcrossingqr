using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public Pattern(Image image)
            : this()
        {
            Bitmap resizedImage = new Bitmap(Width, Height);
            using (Graphics gr = Graphics.FromImage(resizedImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(image, new Rectangle(0, 0, Width, Height));
            }

            BitmapData bitmapData = resizedImage.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            byte[] imagePixelData = new byte[Math.Abs(bitmapData.Stride) * bitmapData.Height];
            Marshal.Copy(bitmapData.Scan0, imagePixelData, 0, imagePixelData.Length);
            resizedImage.UnlockBits(bitmapData);

            LoadFromPixelData(imagePixelData);
        }

        public static Pattern CreateFromRawData(byte[] data)
        {
            Pattern pattern = new Pattern();
            pattern.LoadFromBytes(data);

            return pattern;
        }

        private void LoadFromPixelData(byte[] data)
        {
            Title = "Untitled";
            Author = new User("Someone", "Nowhere", new byte[] { 0, 0, 0, 0, 0, 0 });
            Type = PatternType.Normal;

            Color[,] sourceImage = new Color[Width, Height];
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    sourceImage[i, j] = new Color(data[(j * Height + i) * 3 + 2], data[(j * Height + i) * 3 + 1], data[(j * Height + i) * 3 + 0]);

            HashSet<Color> bestPalette = CreateBestPalette(sourceImage);
            ColorPalette = new Palette();
            int k = 0;
            foreach (Color c in bestPalette)
                ColorPalette.SetColor(k++, c);

            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    Data[i, j] = ColorPalette.GetNearestColorIndex(sourceImage[i, j]);
        }

        private HashSet<Color> CreateBestPalette(Color[,] image)
        {
            HashSet<Color> palette = new HashSet<Color>(image.Cast<Color>().Select(Palette.GetNearestColor));

            while (palette.Count > 15)
                palette.Remove(CalculateLeastImportantColor(image, palette));

            return palette;
        }

        private Color GetNearestColor(HashSet<Color> palette, Color color)
        {
            return palette
                .Aggregate((a, b) => Color.DistanceSquared(a, color) < Color.DistanceSquared(b, color) ? a : b);
        }
        
        private Color GetSecondNearestColor(HashSet<Color> palette, Color color)
        {
            Color nearestColor = GetNearestColor(palette, color);
            return palette
                .Where(c => c != nearestColor)
                .Aggregate((a, b) => Color.DistanceSquared(a, color) < Color.DistanceSquared(b, color) ? a : b);
        }

        private Color CalculateLeastImportantColor(Color[,] image, HashSet<Color> palette)
        {
            Dictionary<Color, double> colorErrorSquaredDelta = new Dictionary<Color, double>();
            foreach (Color c in palette)
                colorErrorSquaredDelta.Add(c, 0);
            
            for (int i = 0; i < image.GetLength(0); i++)
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    Color nearestColor = GetNearestColor(palette, image[i, j]);

                    double currentError = Color.DistanceSquared(image[i, j], nearestColor);
                    double potentialError = Color.DistanceSquared(image[i, j], GetSecondNearestColor(palette, image[i, j]));

                    colorErrorSquaredDelta[nearestColor] += (potentialError - currentError);
                }

            return colorErrorSquaredDelta.Aggregate((a, b) => (a.Value < b.Value) ? a : b).Key;
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

        public byte[] GetRawData()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            NibbleWriter nibbleWriter = new NibbleWriter(binaryWriter);

            //nibbleWriter.WriteByte(0x40);

           // nibbleWriter.WriteByte(0x26);
            //nibbleWriter.WriteNibble(0xC);
            
            nibbleWriter.WriteString(Title, 42);
            Author.Write(nibbleWriter);

            ColorPalette.Write(nibbleWriter);

            nibbleWriter.WriteByte(0x00);
            nibbleWriter.WriteByte(0x0A);
            nibbleWriter.WriteByte((byte)Type);
            nibbleWriter.WriteByte(0x00);
            nibbleWriter.WriteByte(0x00);

            for (int j = 0; j < Data.GetLength(1); j++)
                for (int i = 0; i < Data.GetLength(0); i += 2)
                {
                    nibbleWriter.WriteNibble(Data[i + 1, j]);
                    nibbleWriter.WriteNibble(Data[i, j]);
                }
            //nibbleWriter.WriteNibble(0x0);
            /*nibbleWriter.WriteByte(0xEC);
            nibbleWriter.WriteByte(0x11);
            nibbleWriter.WriteByte(0xEC);
            nibbleWriter.WriteByte(0x11);*/

            byte[] result = memoryStream.ToArray();
            memoryStream.Close();

            return result;
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
