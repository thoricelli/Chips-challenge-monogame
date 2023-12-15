using CHIPS_CHALLENGE.Classes.Items.Enums;
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
                case Objects.FORCE_SOUTH:
                    return new ForceSouth();
                //SKIPPED A FEW OBJECTS :)
                case Objects.FORCE_NORTH:
                    return new ForceNorth();
                case Objects.FORCE_EAST:
                    return new ForceEast();
                case Objects.FORCE_WEST:
                    return new ForceWest();
                case Objects.EXIT:
                    return new Exit();
                case Objects.BLUE_DOOR:
                    return new BlueDoor();
                case Objects.RED_DOOR:
                    return new RedDoor();
                case Objects.GREEN_DOOR:
                    return new GreenDoor();
                case Objects.YELLOW_DOOR:
                    return new YellowDoor();
                //Skipping some objects :D
                case Objects.UNUSED:
                    return new InvisibleWall();
                case Objects.THIEF:
                    return new Thief();
                case Objects.GATE:
                    return new Gate();
                default:
                    return new ChipObject(code);
            }
        }
    }
}
