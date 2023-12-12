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

        //This field, allows the class to mutate itself on the next draw
        //If a Chip gets picked up and needs to change to a tile, then it'll use this.
        public Objects? changeInto = null;

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
        /// Should fire when the object is touched by a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>If the entity can move through it</returns>
        public virtual bool MovingTo(Entity entity) {
            return true;
        }
        /// <summary>
        /// Should fire when an entity moves to another tile.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>If the entity can move from the current tile</returns>
        public virtual bool MovingFrom(Entity entity)
        {
            return true;
        }
    }
}
