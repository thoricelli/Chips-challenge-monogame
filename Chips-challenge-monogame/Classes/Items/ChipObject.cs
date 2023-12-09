using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public /*abstract*/ class ChipObject
    {
        /*
         REFER to https://www.seasip.info/ccfile.html
         */
        public Objects code;
        
        public Sprite Sprite;

        public ChipObject(Objects code, Sprite sprite)
        {
            this.code = code;
            Sprite = sprite;
        }

        public ChipObject(Objects code)
        {
            this.code = code;
            Sprite = new Sprite(CHIP.spritesheet, 1, (int)code); //REPLACE THIS LATER!
        }
        /// <summary>
        /// Should fire when the entity is touched by a player
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>If the player can move through it</returns>
        public virtual bool Touched(Entity entity) {
            return true;
        }
    }
}
