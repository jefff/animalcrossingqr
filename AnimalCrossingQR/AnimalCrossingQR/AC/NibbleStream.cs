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
}
