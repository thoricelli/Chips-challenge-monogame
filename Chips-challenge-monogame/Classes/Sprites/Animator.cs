using CHIPS_CHALLENGE.Classes.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Sprites
{
    public class Animator
    {
        public Sprite[] Sprites;
        //We have 4 sprites for each direction
        /*
         NORTH: SPRITE
         ...ETC
         */
        //The current sprite that's displayed.
        public Sprite Sprite { get { return Sprites[(int)_facing]; } }
        //The direction of the sprite.
        public Facing Facing { get { return _facing; } }
        private Facing _facing;

        public Animator(Sprite North, Sprite East, Sprite South, Sprite West, Facing facing)
        {
            Sprites = new Sprite[]
            {
                North,
                East,
                South,
                West
            };
            this._facing = facing;
        }
        public void ChangeDirection(Facing direction)
        {
            this._facing = direction;
        }

        public void AnimationRenderStepped()
        {
            //For animated sprites.
        }
    }
}
