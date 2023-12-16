using CHIPS_CHALLENGE.Classes.Items.Enums;
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
        public Player() : base((Objects)0x6C)
        {
        }

        public override void LoadSprite()
        {
            this.Sprite = new Sprite(CHIP.spritesheet, 4, (int)Code);
        }
    }
}
