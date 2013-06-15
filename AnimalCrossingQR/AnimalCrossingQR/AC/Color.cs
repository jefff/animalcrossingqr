using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCrossingQR
{
    public class Color
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public Color(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
