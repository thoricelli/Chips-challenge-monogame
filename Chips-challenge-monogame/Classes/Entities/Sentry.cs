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
    public class Sentry : Enemy
    {
        //TODO, sentry can't die to fire...
        public Sentry() 
            : base((Objects)Enemies.FIREBALL,
                  new List<Direction> { Direction.UP, Direction.RIGHT, Direction.LEFT })
        {
        }
    }
}
