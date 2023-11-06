using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Loader.ChipFile
{
    [Serializable]
    public class Base
    {
        public long MagicNo;
        public short NumberOfLevels;
        public Level LoadedLevel;
    }
}
