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
using CHIPS_CHALLENGE.Classes.Utilities;
using CHIPS_CHALLENGE.Classes.Loader;
using CHIPS_CHALLENGE.Classes.Entities.Enums;

namespace CHIPS_CHALLENGE.Classes
{
    public static class ChipGame
    {
        public static ChipFileInformation chipInfo;
        private static Vector2 _spawnLocation;

        public static List<Player> Players { get { return _players; } }

        private static List<Player> _players = new List<Player>(); //Multiplayer is a TODO.

        public static void LoadLevel()
        {
            //Use loader to load next level.
            //ChipFileLoader.LoadLevelFromFile(
        }
        public static void RestartLevel()
        {

        }
        public static Status UpdateTile(Vector2 position)
        {
            Status status = Status.OK;
            int i = GeneralUtilities.ConvertFromVectorToIndex(position);
            foreach (Layer layer in chipInfo.layers)
            {
                ChipObject item = layer.objects[i];
                if (item.changeInto.HasValue)
                    item = ItemFactory.CreateObjectFromCode(item.changeInto.Value);
                if (item.goToDirection.HasValue)
                {
                    //Check if we can move to something (will HAVE to be an empty tile)
                    Vector2 pos = (position + new Vector2(item.goToDirection.Value.X, item.goToDirection.Value.Y * 32));
                    int index = GeneralUtilities.ConvertFromVectorToIndex(pos);
                    if (layer.objects[index].code == Objects.EMPTY)
                    {
                        layer.objects[index] = ItemFactory.CreateObjectFromCode(item.code);
                        layer.objects[i] = ItemFactory.CreateObjectFromCode(Objects.EMPTY);
                    } else
                    {
                        status = Status.MoveBlocked;
                    }
                    item.goToDirection = null;
                }
            }
            return status;
        }
        public static List<ChipObject> CheckCollision(Vector2 position)
        {
            List<ChipObject> chipObjects = new List<ChipObject>();
            int index = GeneralUtilities.ConvertFromVectorToIndex(position);
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

        //What I need from this is: index or position vector goes in,
        //and all the players will have their position changed to that spawn location.
        public static void SetSpawnLocation(int index)
        {
            Vector2 position = GeneralUtilities.ConvertFromIndexToVector(index);
            _spawnLocation = position;
            foreach (Player player in Players)
            {
                player.Position = position;
            }
        }

        public static void AddPlayer(Player player)
        {
            player.Position = _spawnLocation;
            _players.Add(player);
        }
    }
}
