using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Game;
using CHIPS_CHALLENGE.Classes.Game.Enums;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class ForceFloorRandom : ChipObject
    {
        public ForceFloorRandom() : base(Objects.FORCE_FLOOR_RANDOM)
        {
        }
        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            if (!ChipGame.Inventory.ForceShoe)
            {
                Random random = new Random();

                int randomX = 0;
                int randomY = 0;

                do
                {
                    randomX = random.Next(-1, 2);
                    if (randomX == 0)
                        randomY = random.Next(-1, 2);
                } while (randomX == 0 && randomY == 0);

                entity.AddPush(new Push(new Vector2(randomX, randomY), PushType.MOVEMENT_ENABLED));
            }
        }
    }
}
