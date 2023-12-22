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
using CHIPS_CHALLENGE.Classes.Game;
using CHIPS_CHALLENGE.Classes.Input;
using CHIPS_CHALLENGE.Classes.States;
using CHIPS_CHALLENGE.Classes.UI;
using SharpDX.MediaFoundation;
using System.Threading;

namespace CHIPS_CHALLENGE.Classes
{
    public static class ChipGame
    {
        public static ChipFileInformation chipInfo { get; set; }
        public static Inventory Inventory = new Inventory();
        private static Vector2 _spawnLocation { get; set; }
        private static ChipFileLoader chipFileLoader = new ChipFileLoader(".\\Content\\CHIPS.DAT");
        
        public static PlayerInputHandler thisPlayerInput { get; set; }

        public static List<Player> Players { get { return _players; } }

        private static List<Player> _players = new List<Player>(); //Multiplayer is a TODO.

        public static List<Enemy> Enemies { get { return _enemies; } }
        public static List<Enemy> _enemies = new List<Enemy>();

        private static bool hasGameStarted = false;

        /*
         CONFIG IS TEMPORARILY HERE!
         */
        private static int UpdateEnemiesMs = 500;
        private static int UpdatePushMs = 150;

        private static double LastEnemyUpdate = 0;
        private static double LastPushUpdate = 0;

        public static void LoadLevel(int level)
        {
            ResetAll();
            chipInfo = chipFileLoader.LoadLevelFromFile(level);
            LevelHasChanged();
        }
        public static void LoadNext()
        {
            ResetAll();
            chipInfo = chipFileLoader.LoadLevelFromFile(chipInfo.LevelNumber+1);
            LevelHasChanged();
        }
        public static void RestartLevel()
        {
            ResetAll();
            chipInfo = chipFileLoader.LoadLevelFromFile(chipInfo.LevelNumber);
            LevelHasChanged();
        }
        public static void LevelHasChanged()
        {
            if (InGameState.gameUI != null)
                InGameState.gameUI.ShowMapTitle(chipInfo.MapTitle);
        }
        public static void ResetAll()
        {
            //Make players alive again.
            _enemies = new List<Enemy>();
            if (InGameState.gameUI != null)
                InGameState.gameUI.LevelChanged();
            hasGameStarted = false;
            ResetAllItems();
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
                    Vector2 pos = (position + new Vector2(item.GoToDirection.Value.X*32, item.GoToDirection.Value.Y * 32));
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
            chipInfo.ChipsToPickUp--;
        }
        public static void ResetAllItems()
        {
            Inventory.ResetAllItems();
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
        public static void PlayerDied(Player player)
        {
            /*InGameState.gameUI.ShowYouDied();
            InGameState.gameUI.HideYouDied();*/
            RestartLevel();
            player.Revive();
        }

        public static void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public static void StartGame()
        {
            hasGameStarted = true;
            InGameState.gameUI.HideMapTitle();
        }

        public static void Update(GameTime gameTime)
        {
            thisPlayerInput.HandleInput();
            //Every X seconds update enemies.
            if (hasGameStarted)
            {
                double totalMiliseconds = gameTime.TotalGameTime.TotalMilliseconds;
                int enemyno = 0;
                if (totalMiliseconds - LastEnemyUpdate >= UpdateEnemiesMs)
                {
                    foreach (Enemy enemy in Enemies)
                    {
                        enemyno++;
                        enemy.Update();
                    }
                    LastEnemyUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                }
                //Every X seconds update push for entities.
                if (totalMiliseconds - LastPushUpdate >= UpdatePushMs)
                {
                    foreach (Entity entity in Players)
                    {
                        entity.HandlePush();
                    }
                    //What about enemies?
                    LastPushUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                }
            }
        }
        public static Player CheckPlayerTouched(Vector2 position)
        {
            foreach (Player player in _players)
            {
                if (player.Position == position)
                    return player;
            }
            return null;
        }
    }
}
