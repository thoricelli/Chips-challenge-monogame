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
        public Player() : base(
            Objects.HERO_NORTH,
            new Sprite(CHIP.spritesheet, 4, (int)Objects.HERO_NORTH),
            new Sprite(CHIP.spritesheet, 4, ((int)Objects.HERO_NORTH) + 1),
            new Sprite(CHIP.spritesheet, 4, ((int)Objects.HERO_NORTH) + 2),
            new Sprite(CHIP.spritesheet, 4, ((int)Objects.HERO_NORTH) + 3))
        {
        }
    }
}
