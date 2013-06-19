using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCrossingQR.AC
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

        public User(NibbleReader nibbleReader)
        {
            UniqueID = new byte[6];

            UniqueID[0] = nibbleReader.ReadByte();
            UniqueID[1] = nibbleReader.ReadByte();
            Name = nibbleReader.ReadString(20);
            UniqueID[2] = nibbleReader.ReadByte();
            UniqueID[3] = nibbleReader.ReadByte();
            Town = nibbleReader.ReadString(20);
            UniqueID[4] = nibbleReader.ReadByte();
            UniqueID[5] = nibbleReader.ReadByte();
        }
    }
}
