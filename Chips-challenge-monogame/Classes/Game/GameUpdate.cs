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
