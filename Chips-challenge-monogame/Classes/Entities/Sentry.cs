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
        public Sentry(Vector2 position, Facing facing) 
            : base((Objects)Enemies.SENTRY,
                  position,
                  new Direction[] { Direction.UP, Direction.RIGHT, Direction.LEFT },
                  new Objects[] { Objects.EMPTY, Objects.FIRE, Objects.WATER },
                  facing)
        {
        }
    }
}
