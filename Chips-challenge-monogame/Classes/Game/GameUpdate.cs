using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Entities.Enums;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Game
{
    //Is used for updating sprites when needed.
    public static class GameUpdate
    {
        //find, replace
        public static List<FindReplace> replaceTiles = new List<FindReplace>();
        public static void ReplaceTile(Objects find, Objects replace)
        {
            replaceTiles.Add(new FindReplace(find, replace));
        }
        public static void SwitchDirection(Enemies enemyCode)
        {
            foreach (Enemy enemy in ChipGame.Enemies)
            {
                if (enemy.Code == (Objects)enemyCode)
                {
                    Facing facing = Facing.NORTH;
                    //Too lazy to do math here.
                    switch (enemy.Facing)
                    {
                        case Entities.Enums.Facing.NORTH:
                            facing = Facing.SOUTH;
                            break;
                        case Entities.Enums.Facing.WEST:
                            facing = Facing.EAST;
                            break;
                        case Entities.Enums.Facing.SOUTH:
                            facing = Facing.NORTH;
                            break;
                        case Entities.Enums.Facing.EAST:
                            facing = Facing.WEST;
                            break;
                    }
                    enemy.ChangeDirection(facing);
                }
            }
        }
        public static ChipObject Update(ChipObject obj)
        {
            int index = replaceTiles.FindIndex(item => item.Find == obj.code);
            if (index > -1)
            {
                obj = ItemFactory.CreateObjectFromCode(replaceTiles[index].Replace);
            }
            return obj;
        }
        public static void ClearUpdateList()
        {
            replaceTiles = new List<FindReplace>();
        }
    }
}
