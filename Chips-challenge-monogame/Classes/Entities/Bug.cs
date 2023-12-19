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
    public class Bug : Enemy
    {
        public Bug(Vector2 position) : base((Objects)Enemies.BUG, position)
        {
        }
        //TODO move this to generic
        private Direction[] directions = new Direction[] { Direction.LEFT, Direction.UP, Direction.RIGHT };
        public override void Update()
        {
            /*
             * The bug will always try to move to the LEFT
             * It'll only try to move on empty tiles.
             * It'll try to go left (From the way it's facing)
             */
            //This depends on the orientation though...
            int triedDirections = 0;
            bool blocked = false;
            do
            {
                blocked = false;

                Vector2 velocity = GeneralUtilities.SpriteFacingToVector(
                                                directions[triedDirections],
                                                this.Facing
                                                );
                List<ChipObject> chipObjects =
                    ChipGame.CheckCollision(this.Position + velocity * 32);
                foreach (ChipObject item in chipObjects)
                {
                    if (item.code != Objects.EMPTY)
                    {
                        blocked = true;
                    } else if (!blocked)
                    {
                        Move(velocity);
                        break; //TODO, remove...
                    }
                }
                triedDirections++;
            } while (triedDirections < 3 && blocked);
        }
    }
}
