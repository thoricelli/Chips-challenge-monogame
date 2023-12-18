using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Utilities;
using Microsoft.Xna.Framework;
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
        public override void Update()
        {
            /*
             * The bug will always try to move to the LEFT
             * It'll only try to move on empty tiles.
             * It'll try to go left (From the way it's facing)
             */
            //This depends on the orientation though...
            /*List<ChipObject> chipObjects =
                ChipGame.CheckCollision(this.Position +
                                        GeneralUtilities.SpriteFacingToVector() 
                                        * 32);*/
        }
    }
}
