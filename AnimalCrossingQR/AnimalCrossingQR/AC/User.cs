using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCrossingQR
{
    public class User
    {
        public string Name { get; set; }
        public string Town { get; set; }
        public byte[] UniqueID { get; set; }

        public User(string name, string town, byte[] uniqueID)
        {
            Name = name;
            Town = town;
            UniqueID = uniqueID;
        }
    }
}
