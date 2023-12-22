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
                case Objects.ICE_CORNER_NORTHWEST:
                    return new IceCornerNorthWest();
                case Objects.ICE_CORNER_NORTHEAST:
                    return new IceCornerNorthEast();
                case Objects.ICE_CORNER_SOUTHEAST:
                    return new IceCornerSouthEast();
                case Objects.ICE_CORNER_SOUTHWEST:
                    return new IceCornerSouthWest();
                case Objects.BLUE_BLOCK_EMPTY:
                    return new BlueBlockEmpty();
                case Objects.BLUE_BLOCK_WALL:
                    return new BlueBlock();
                case Objects.UNUSED:
                    return new InvisibleWall();
                case Objects.THIEF:
                    return new Thief();
                case Objects.GATE:
                    return new Gate();
                case Objects.WALL_BUTTON:
                    return new WallButton();
                case Objects.TOGGLE_WALL_ON:
                    return new ToggleWallOn();
                //Skipping some objects.
                case Objects.TANK_BUTTON:
                    return new TankButton();
                //Skip
                case Objects.BOMB:
                    return new Bomb();
                //Skipping some objects
                case Objects.INVISIBLE_WALL_APPEAR:
                    return new InvisibleWallAppear();
                //Gravel doesn't need a switch.
                //Skipping some objects
                case Objects.HINT:
                    return new Hint();
                case Objects.THIN_WALL:
                    return new ThinWall();
                //Skipping objects
                case Objects.FORCE_FLOOR_RANDOM:
                    return new ForceFloorRandom();
                //Skipping objects
                case Objects.BLUE_KEY:
                    return new BlueKey();
                case Objects.RED_KEY:
                    return new RedKey();
                case Objects.GREEN_KEY:
                    return new GreenKey();
                case Objects.YELLOW_KEY:
                    return new YellowKey();
                case Objects.WATER_SHOE:
                    return new WaterShoe();
                case Objects.FIRE_SHOE:
                    return new FireShoe();
                case Objects.ICE_SHOE:
                    return new IceShoe();
                case Objects.FORCE_SHOE:
                    return new ForceShoe();
                default:
                    return new ChipObject(code);
            }
        }
    }
}
