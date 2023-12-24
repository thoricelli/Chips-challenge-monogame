using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Entities
{
    public class Teeth : Enemy
    {
        public Teeth() 
            : base((Objects)Enemies.TEETH)
        {
        }

        public override void Update()
        {
            /*
             * Teeth will want to try to move to the same X/Y position
             * If the difference between the X or Y position is greater (whichever comes first)
             * then it'll try to move in that direction, if it can't, it'll try the other axis
             */
            //Get closest chip's position
            Player player = ChipGame.GetNearbyPlayer(this.Position);
            //Check difference between our X/Y and chips'
            int xDifference = (int)(player.Position.X - this.Position.X);
            int yDifference = (int)(player.Position.Y - this.Position.Y);

            int xVelocity = Math.Sign(xDifference);
            int yVelocity = Math.Sign(yDifference);
            //IF X's difference is greater, move in the X direction (by 1)
            //IF Y's difference is greater than X's, move in the Y direction (by 1)
            //IF it can't, try the reverse axis.

            if (yDifference > xDifference)
            {
                if (!TryMoving(new Vector2(0, yVelocity)))
                    TryMoving(new Vector2(xVelocity, 0));
            } else {
                if (!TryMoving(new Vector2(xVelocity, 0)))
                    TryMoving(new Vector2(0, yVelocity));
            }
        }

        public bool TryMoving(Vector2 velocity)
        {
            Vector2 positionToX = this.Position + velocity * 32;

            return CheckMovement(positionToX) && this.Move(velocity);
        }
    }
}
