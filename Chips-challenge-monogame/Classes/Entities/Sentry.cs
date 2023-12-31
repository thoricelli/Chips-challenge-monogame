﻿using CHIPS_CHALLENGE.Classes.Entities.Enums;
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
        public Sentry() 
            : base((Objects)Enemies.FIREBALL,
                  new List<Direction> { Direction.UP, Direction.RIGHT, Direction.LEFT, Direction.DOWN })
        {
        }
        public override bool CanMoveTo(Objects code, Vector2 movingTo)
        {
            switch (code)
            {
                case Objects.FIRE:
                    return true;
            }
            return base.CanMoveTo(code, movingTo);
        }
        public override void Kill(Objects killedBy)
        {
            if (killedBy != Objects.FIRE)
                base.Kill(killedBy);
        }
    }
}
