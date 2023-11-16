using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Loader.ChipFile.Fields
{
    //MOVEMENT
    /*
     Each Monster placed on the map must be listed in this field in order for movement to occur. If not listed, it will simply remain in its starting position. 
     */
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Field10 : Field
    {
        public Monster[] monsters;
    }
}
