﻿using System;
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
        private static ChipFileLoader chipFileLoader = new ChipFileLoader(".\\Content\\CHIPS.DAT");

        public static List<Player> Players { get { return _players; } }

        private static List<Player> _players = new List<Player>(); //Multiplayer is a TODO.

        public static void LoadLevel(int level)
        {
            chipInfo = chipFileLoader.LoadLevelFromFile(level);
        }
        public static void LoadNext()
        {
            chipInfo = chipFileLoader.LoadLevelFromFile(chipInfo.currentLevel.LevelNumber+1);
        }
        public static void RestartLevel()
        {
            chipInfo = chipFileLoader.LoadLevelFromFile(chipInfo.currentLevel.LevelNumber);
        }
        public static Status UpdateTile(Vector2 position)
        {
            Status status = Status.OK;
            int i = GeneralUtilities.ConvertFromVectorToIndex(position);
            foreach (Layer layer in chipInfo.layers)
            {
                ChipObject item = layer.objects[i];
                if (item.ChangeInto.HasValue)
                    layer.objects[i] = ItemFactory.CreateObjectFromCode(item.ChangeInto.Value);
                if (item.GoToDirection.HasValue)
                {
                    //Check if we can move to something (will HAVE to be an empty tile)
                    Vector2 pos = (position + new Vector2(item.GoToDirection.Value.X, item.GoToDirection.Value.Y * 32));
                    int index = GeneralUtilities.ConvertFromVectorToIndex(pos);

                    Objects? transformInto = item.TileMove(layer.objects[index].code);
                    if (transformInto.HasValue)
                    {
                        layer.objects[index] = ItemFactory.CreateObjectFromCode((Objects)transformInto);
                        layer.objects[i] = ItemFactory.CreateObjectFromCode(Objects.EMPTY);
                    } else
                    {
                        status = Status.MoveBlocked;
                    }
                    item.MoveObjectInDirection(null);
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
