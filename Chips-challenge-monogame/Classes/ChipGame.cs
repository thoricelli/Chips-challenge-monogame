using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.Items.Enums;

namespace CHIPS_CHALLENGE.Classes
{
    public static class ChipGame
    {
        public static ChipFileInformation chipInfo;

        public static List<Player> Players { get; set; } = new List<Player>(); //Multiplayer is a TODO.

        public static void LoadLevel()
        {
            //Use loader to load next level.
        }
        public static void RestartLevel()
        {

        }
        public static List<ChipObject> CheckCollision(Vector2 position)
        {
            List<ChipObject> chipObjects = new List<ChipObject>();
            int index = (int)((position.X / 32) + (position.Y));
            foreach (Layer layer in chipInfo.layers)
            {
                chipObjects.Add(layer.objects[index]);
            }
            return chipObjects;
        }
        public static void ChipPickedUp()
        {
            chipInfo.currentLevel.ChipsToPickUp--;
        }

        //Should I move this somewhere else maybe...?
        public static ChipObject CreateObjectFromCode(Objects code)
        {
            switch (code)
            {
                case Objects.WALL:
                    return new Wall();
                    break;
                default:
                    return new ChipObject(code);
                    break;
            }
        }

        public static void SetSpawnLocation()
    }
}
