using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.States;
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
            new Sprite(InGameState.spritesheet, 4, (int)Objects.HERO_NORTH),
            new Sprite(InGameState.spritesheet, 4, ((int)Objects.HERO_NORTH) + 1),
            new Sprite(InGameState.spritesheet, 4, ((int)Objects.HERO_NORTH) + 2),
            new Sprite(InGameState.spritesheet, 4, ((int)Objects.HERO_NORTH) + 3))
        {
        }
        public override void Kill(Objects killedBy)
        {
            base.Kill(killedBy);
            ChipGame.PlayerDied(this);
        }
    }
}
