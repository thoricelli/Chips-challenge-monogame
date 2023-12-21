using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Game
{
    public struct FindReplace
    {
        public Objects Find;
        public Objects Replace;

        public FindReplace(Objects find, Objects replace)
        {
            Find = find;
            Replace = replace;
        }
    }
}
