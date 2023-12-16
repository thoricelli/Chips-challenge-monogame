using CHIPS_CHALLENGE.Classes.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Loader.ChipFile
{
    public class ChipFileInformation
    {
        public ushort NumberOfLevels { get; set; }

        public ushort LevelNumber { get; set; }
        public ushort Time { get; set; }
        public ushort ChipsToPickUp { get; set; }

        public List<Layer> layers = new List<Layer>();

        //Replace this stuff, it ain't great. + lots of unneeded overhead
        public Field[] fields = new Field[11]; //We have 11 fields max, only accessible with functions.
    }
}
