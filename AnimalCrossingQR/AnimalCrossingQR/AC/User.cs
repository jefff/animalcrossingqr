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
            UniqueID = new byte[10];

            UniqueID[0] = nibbleReader.ReadByte();
            UniqueID[1] = nibbleReader.ReadByte();
            Name = nibbleReader.ReadString(20);
            UniqueID[2] = nibbleReader.ReadByte();
            UniqueID[3] = nibbleReader.ReadByte();
            Town = nibbleReader.ReadString(16);

            // This group seems to be 00 00 00 00 in Japan, and
            //  00 00 01 00 in the US. All 4 bytes are saved just
            //  in case.
            UniqueID[6] = nibbleReader.ReadByte();
            UniqueID[7] = nibbleReader.ReadByte();
            UniqueID[8] = nibbleReader.ReadByte();
            UniqueID[9] = nibbleReader.ReadByte();

            UniqueID[4] = nibbleReader.ReadByte();
            UniqueID[5] = nibbleReader.ReadByte();
        }

        public void Write(NibbleWriter nibbleWriter)
        {
            nibbleWriter.WriteByte(UniqueID[0]);
            nibbleWriter.WriteByte(UniqueID[1]);
            nibbleWriter.WriteString(Name, 20);
            nibbleWriter.WriteByte(UniqueID[2]);
            nibbleWriter.WriteByte(UniqueID[3]);
            nibbleWriter.WriteString(Town, 16);
            
            nibbleWriter.WriteByte(UniqueID[6]);
            nibbleWriter.WriteByte(UniqueID[7]);
            nibbleWriter.WriteByte(UniqueID[8]);
            nibbleWriter.WriteByte(UniqueID[9]);

            nibbleWriter.WriteByte(UniqueID[4]);
            nibbleWriter.WriteByte(UniqueID[5]);
            
        }
    }
}
