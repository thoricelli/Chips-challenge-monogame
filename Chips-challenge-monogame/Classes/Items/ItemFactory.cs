﻿using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    //Static for now.
    public static class ItemFactory
    {
        public static ChipObject CreateObjectFromCode(Objects code)
        {
            //Replace with an array maybe? Idk.
            switch (code)
            {
                case Objects.WALL:
                    return new Wall();
                case Objects.COMPUTER_CHIP:
                    return new Chip();
                case Objects.WATER:
                    return new Water();
                case Objects.FIRE:
                    return new Fire();
                case Objects.INVISIBLE_WALL:
                    return new InvisibleWall();
                case Objects.THIN_NORTH:
                    return new ThinNorth();
                case Objects.THIN_WEST:
                    return new ThinWest();
                case Objects.THIN_SOUTH:
                    return new ThinSouth();
                case Objects.THIN_EAST:
                    return new ThinEast();
                case Objects.BLOCK:
                    return new Block();
                case Objects.DIRT:
                    return new Dirt();
                case Objects.ICE:
                    return new Ice();
                default:
                    return new ChipObject(code);
            }
        }
    }
}
