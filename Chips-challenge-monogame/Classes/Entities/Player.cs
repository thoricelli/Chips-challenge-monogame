using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.States;
using Microsoft.Xna.Framework;
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
            new Sprite(InGameState.chipAni, 8, 0, false),
            new Sprite(InGameState.chipAni, 8, 24, false),
            new Sprite(InGameState.chipAni, 8, 16, false),
            new Sprite(InGameState.chipAni, 8, 8, false))
        {
        }
        public override void Kill(Objects killedBy)
        {
            base.Kill(killedBy);
            ChipGame.PlayerDied(this);
        }
        public override bool Move(Vector2 velocity)
        {
            Enemy enemy = ChipGame.CheckEntityTouched(this.Position + velocity * 32) as Enemy;
            if (enemy != null)
                this.Kill(enemy.Code);
            /*Player player = ChipGame.CheckPlayerTouched(this.Position + velocity * 32);
            if (player != null)
            {
                velocity = Vector2.Zero;
                return false;
            }*/
            return base.Move(velocity);
        }
        private int times = 0;
        public void UpdateSmoothMovement()
        {

            DisplayPosition += MoveByForSmooth;
            times++;

            if (times >= 8)
            {
                MovementEnabled = true;
                isSmoothMoving = false;
                times = 0;
                HandlePush();
            }

            //WHEN displayposition == position, done, stop animation, stop at the first frame.
        }
    }
}
