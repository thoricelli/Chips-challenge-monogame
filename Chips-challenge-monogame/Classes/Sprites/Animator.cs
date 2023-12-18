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
        public Sprite Sprite { get { return Sprites[(int)_direction]; } }
        //The direction of the sprite.
        private Direction _direction;

        public Animator(Sprite North, Sprite East, Sprite South, Sprite West)
        {
            Sprites = new Sprite[]
            {
                North,
                East,
                South,
                West
            };
        }
        public void ChangeDirection(Direction direction)
        {
            this._direction = direction;
        }

        public void AnimationRenderStepped()
        {
            //For animated sprites.
        }
    }
}
