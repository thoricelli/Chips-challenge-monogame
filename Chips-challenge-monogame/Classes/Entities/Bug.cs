using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Items.Enums;
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
            //First we try to move left.
            //This depends on the orientation though...
            List<ChipObject> chipObjects = 
                ChipGame.CheckCollision(this.Position + 
                                        new Vector2() * 32);
        }
    }
}
