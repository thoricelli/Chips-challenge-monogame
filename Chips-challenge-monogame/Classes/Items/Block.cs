﻿using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Block : ChipObject
    {
        public Block() : base(Objects.BLOCK)
        {
        }

        public override bool MovingTo(Entity entity)
        {
            this.MoveObjectInDirection(entity.Velocity);
            return true; //Depending on if it's moved or not.....
        }

        public override Objects? TileMove(Objects obj)
        {
            switch (obj)
            {
                case Objects.WATER:
                    return Objects.DIRT;
                case Objects.TELEPORT_BUTTON:
                    return code;
            }
            return base.TileMove(obj);
        }
    }
}
