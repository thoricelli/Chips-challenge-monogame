using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Entities
{
    public class Enemy : Entity
    {
        public Enemy(Objects code, Vector2 position)
            : base(code,
                  new Sprite(CHIP.spritesheet, 1, (int)code), //N
                  new Sprite(CHIP.spritesheet, 1, (int)code + 1), //E
                  new Sprite(CHIP.spritesheet, 1, (int)code + 2), //S
                  new Sprite(CHIP.spritesheet, 1, (int)code + 3)) //W
        {
            this.Position = position;
        }
        public override bool Move(Vector2 velocity)
        {
            bool move = base.Move(velocity);
            Player playerHit = ChipGame.CheckPlayerTouched(this.Position);
            if (playerHit != null)
                playerHit.Kill();
            return move;
        }
        //Update enemy movement
        public virtual void Update()
        {

        }
    }
}
