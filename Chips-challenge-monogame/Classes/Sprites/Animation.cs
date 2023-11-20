using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Sprites
{
    public class Animation
    {
        public string Name { get; set; }
        //Indexes of the sprites that need playing.
        //HM, is there another way of doing this?
        public List<int> SpriteIndexes { get; set; }
    }
}
