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
        public Base baseInfo;
        public Level currentLevel;

        public List<Layer> layers;

        private Field[] fields = new Field[10]; //We have 10 fields max, only accessible with functions.
    }
}
