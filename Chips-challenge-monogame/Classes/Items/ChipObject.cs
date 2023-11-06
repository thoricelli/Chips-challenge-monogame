using CHIPS_CHALLENGE.Classes.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class ChipObject
    {
        /*
         REFER to https://www.seasip.info/ccfile.html
         Objects have a beginning and end code,
         since originally every sprite has their own number...
         */
        public int ObjectBaseCode;
        public int ObjectEndCode;
        
        public Sprite Sprite;

        public ChipObject(int objectBaseCode, int objectEndCode, Sprite sprite)
        {
            ObjectBaseCode = objectBaseCode;
            ObjectEndCode = objectEndCode;
            Sprite = sprite;
        }
    }
}
