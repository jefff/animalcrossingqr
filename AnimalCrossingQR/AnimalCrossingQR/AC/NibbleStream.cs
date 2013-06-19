using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AnimalCrossingQR.AC
{
    public class NibbleReader
    {
        private Encoding encoding = Encoding.GetEncoding("UTF-16LE");

        private BinaryReader binaryReader;

        private bool byteAligned = true;
        private byte halfReadByte;

        public NibbleReader(BinaryReader binaryReader)
        {
            this.binaryReader = binaryReader;
        }

        public byte ReadNibble()
        {
            if (byteAligned)
            {
                halfReadByte = binaryReader.ReadByte();
                byteAligned = false;
                return (byte)(halfReadByte >> 4);
            }
            else
            {
                byteAligned = true;
                return (byte)(halfReadByte & 0xF);
            }
        }

        public byte ReadByte()
        {
            byte highNibble = ReadNibble();
            byte lowNibble = ReadNibble();

            return (byte)((highNibble << 4) | lowNibble);
        }

        public string ReadString(int rawLength)
        {
            byte[] rawData = new byte[rawLength];

            for (int i = 0; i < rawData.Length; i++)
                rawData[i] = ReadByte();
                        
            return encoding.GetString(rawData).TrimEnd(new [] { '\0' });
        }
    }

    public class NibbleWriter
    {
        private Encoding encoding = Encoding.GetEncoding("UTF-16LE");

        private BinaryWriter binaryWriter;

        private bool byteAligned = true;
        private byte halfWrittenByte;

        public int NibblesWritten { get; private set; }

        public NibbleWriter(BinaryWriter binaryWriter)
        {
            this.binaryWriter = binaryWriter;
            NibblesWritten = 0;
        }

        public void WriteNibble(int value)
        {
            WriteNibble((byte)value);
        }

        public void WriteNibble(byte value)
        {
            if (byteAligned)
            {
                halfWrittenByte = (byte)(value << 4);
                byteAligned = false;
            }
            else
            {
                halfWrittenByte |= value;
                binaryWriter.Write(halfWrittenByte);
                byteAligned = true;
            }

            NibblesWritten++;
        }

        public void WriteByte(byte value)
        {
            WriteNibble(value >> 4);
            WriteNibble(value & 0xF);
        }

        public void WriteString(string value, int rawLength)
        {
            byte[] data = encoding.GetBytes(value);
            byte[] finalData = new byte[rawLength];

            Array.Copy(data, finalData, Math.Min(data.Length, finalData.Length));
            foreach (byte b in finalData)
                WriteByte(b);
        }
    }
}
