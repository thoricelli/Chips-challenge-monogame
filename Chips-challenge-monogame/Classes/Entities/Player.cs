using CHIPS_CHALLENGE.Classes.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Entities
{
    public class Player : Entity
    {
        public override void LoadSprite()
        {
            this.Sprite = new Sprite(CHIP.spritesheet, 4, 0x6C);
        }
    }
}
