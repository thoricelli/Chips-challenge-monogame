using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Loader.ChipFile.Fields
{
    //MOVEMENT
    /*
     Each Monster placed on the map must be listed in this field in order for movement to occur. If not listed, it will simply remain in its starting position. 
     */
    public class Field10
    {
        public List<Monster> monsters;
    }
}
