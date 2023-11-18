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
        //This shouldn't be here, those are the structures used for file reading
        //We want a clear class with info, nothing extra that is just used for file reading.
        //Plus, this class isn't supposed to be here, move it somewhere else.
        public Base baseInfo;
        public Level currentLevel;

        public List<Layer> layers = new List<Layer>();

        //Replace this stuff, it ain't great. + lots of unneeded overhead
        public Field[] fields = new Field[11]; //We have 11 fields max, only accessible with functions.
    }
}
