﻿using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class InvisibleWallAppear : ChipObject
    {
        public InvisibleWallAppear() : base(Objects.INVISIBLE_WALL_APPEAR)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            this.ChangeObjectInto(Objects.WALL);
            return false;
        }
    }
}
