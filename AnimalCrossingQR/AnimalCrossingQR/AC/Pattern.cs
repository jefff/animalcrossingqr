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
        public byte[,] Data { get; set; }

        public Pattern()
        {
            Data = new byte[Width, Height];
        }

        public Pattern(byte[] rawData)
        {

        }

        private Pattern(BinaryReader binaryReader)
        {

        }
    }

    private class NibbleReader
    {
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
                return halfReadByte >> 4;
            }
            else
            {
                byteAligned = true;
                return halfReadByte & 0xF;
            }
        }

        public byte ReadByte()
        {
            byte highNibble = ReadNibble();
            byte lowNibble = ReadNibble();

            return (highNibble << 4) || lowNibble;
        }
    }
}
