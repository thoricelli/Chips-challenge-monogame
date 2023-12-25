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
using CHIPS_CHALLENGE.Classes.Game;
using CHIPS_CHALLENGE.Classes.Input;
using CHIPS_CHALLENGE.Classes.States;
using CHIPS_CHALLENGE.Classes.UI;
using SharpDX.MediaFoundation;
using System.Threading;
using Trap = CHIPS_CHALLENGE.Classes.Loader.ChipFile.Trap;
using CHIPS_CHALLENGE.Classes.Interfaces;
using System.Drawing;

namespace CHIPS_CHALLENGE.Classes
{
    public static class ChipGame
    {
        public static ChipFileInformation chipInfo { get; set; }
        public static Inventory Inventory = new Inventory();
        private static Vector2 _spawnLocation { get; set; }
        public static ChipFileLoader chipFileLoader = new ChipFileLoader(".\\Content\\CHIPS.DAT");

        public static IInputHandler thisPlayerInput { get; set; }

        public static List<Player> Players { get { return _players; } }

        private static List<Player> _players = new List<Player>(); //Multiplayer is a TODO.

        public static List<Enemy> Enemies { get { return _enemies; } }
        public static List<Enemy> _enemies = new List<Enemy>();

        public static Func<object> gameOverHandler;
        public static Func<object> wonHandler;

        public static List<Entity> Entities { get {
                List<Entity> entities = new List<Entity>();
                entities.AddRange(Players);
                entities.AddRange(Enemies);
                return entities;
            } 
        }

        private static bool hasGameStarted = false;

        /*
         CONFIG IS TEMPORARILY HERE!
         */
        public static int UpdateSmoothPosition = 8;
        private static int UpdateEnemiesMs = 520;
        private static int UpdatePushMs = 120;

        private static double LastSmoothUpdate = 0;
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
            if (chipInfo.NumberOfLevels >= chipInfo.LevelNumber + 1)
            {
                chipInfo = chipFileLoader.LoadLevelFromFile(chipInfo.LevelNumber + 1);
                LevelHasChanged();
            } else
            {
                wonHandler();
            }
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
                    Vector2 velocity = new Vector2(item.GoToDirection.Value.X * 32, item.GoToDirection.Value.Y * 32);
                    Vector2 pos = (position + velocity);
                    int index = GeneralUtilities.ConvertFromVectorToIndex(pos);

                    ChipObject goToObject = layer.objects[index];
                    Objects? transformInto = item.TileMove(goToObject.code);
                    if (transformInto.HasValue)
                    {
                        ChipObject tileMoveTo = layer.objects[index];

                        if (tileMoveTo is IPressable)
                        {
                            (tileMoveTo as IPressable).Press(pos);
                            ChipGame.chipInfo.layers[1].objects[index] = ChipGame.chipInfo.layers[0].objects[index];
                            ChipGame.chipInfo.layers[0].objects[index] = ItemFactory.CreateObjectFromCode((Objects)transformInto);
                        } else if (tileMoveTo is TeleportButton)
                        {
                            TeleportButton teleporter = tileMoveTo as TeleportButton;
                            layer.objects[
                                GeneralUtilities.ConvertFromVectorToIndex(teleporter.GetTeleportPosition(pos) + velocity)
                                ]
                                = ItemFactory.CreateObjectFromCode((Objects)transformInto);
                        }
                        else
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
                player.ChangePosition(position);
            }
        }

        public static void AddPlayer(Player player)
        {
            player.ChangePosition(_spawnLocation);
            _players.Add(player);
        }
        public static void PlayerDied(Player player)
        {
            /*InGameState.gameUI.ShowYouDied();
            InGameState.gameUI.HideYouDied();*/
            //RestartLevel();
            //player.Revive();
            gameOverHandler();
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
                    foreach (Enemy enemy in Enemies.ToList())
                    {
                        enemyno++;
                        enemy.Update();
                    }
                    LastEnemyUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                }
                //Every X seconds update push for entities.
                if (totalMiliseconds - LastPushUpdate >= UpdatePushMs)
                {
                    foreach (Entity entity in Entities)
                    {
                        entity.HandlePush();
                    }
                    LastPushUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                }
                //Every X seconds update smooth movement.
                if (totalMiliseconds - LastSmoothUpdate >= UpdateSmoothPosition)
                {
                    foreach (Player player in Players)
                    {
                        if (player.isSmoothMoving)
                        {
                            player.UpdateSmoothMovement();
                            player.AnimationRenderStepped();
                        }
                        else
                        {
                            player.Sprite.ResetSprite();
                        }
                        
                    }
                    LastSmoothUpdate = gameTime.TotalGameTime.TotalMilliseconds;
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
        public static Entity CheckEntityTouched(Vector2 position)
        {
            foreach (Entity entity in Entities)
            {
                if (entity.Position == position)
                    return entity;
            }
            return null;
        }
        public static Vector2 PositionOfTileInReverse(Objects obj, Vector2 startVector)
        {
            foreach (Layer layer in chipInfo.layers)
            {
                int startIndex = GeneralUtilities.ConvertFromVectorToIndex(startVector);
                for (int i = startIndex-1; i >= 0; i--)
                {
                    ChipObject chipObj = layer.objects[i];
                    if (chipObj.code == obj)
                        return GeneralUtilities.ConvertFromIndexToVector(i);
                }
                //TODO seperate function....
                for (int i = layer.objects.Length-1; i > startIndex; i--)
                {
                    ChipObject chipObj = layer.objects[i];
                    if (chipObj.code == obj)
                        return GeneralUtilities.ConvertFromIndexToVector(i);
                }
            }
            return startVector;
        }
        public static void ReleaseEnemy(Vector2 buttonPosition)
        {
            Trap? trap = GetTrapFromButtonPosition(buttonPosition);
            if (trap.HasValue)
            {
                Entity entity = CheckEntityTouched(new Vector2(trap.Value.ObjectX*32, trap.Value.ObjectY*32));
                if (entity != null)
                    entity.waitToBeReleased = true;
            }
        }
        public static Trap? GetTrapFromButtonPosition(Vector2 buttonPosition)
        {
            foreach (Trap trap in chipInfo.Traps)
            {
                if (new Vector2(trap.ButtonX, trap.ButtonY) == buttonPosition / 32)
                    return trap;
            }
            return null;
        }
        public static CloneMachine? GetCloneFromButtonPosition(Vector2 buttonPosition)
        {
            foreach (CloneMachine cloner in chipInfo.CloneMachines)
            {
                if (new Vector2(cloner.ButtonX, cloner.ButtonY) == buttonPosition / 32)
                    return cloner;
            }
            return null;
        }
        public static void CloneEnemy(Enemy entity)
        {
            if (entity != null)
                Enemies.Add(EnemyFactory.CreateObjectFromCode(entity.Code + (int)entity.Facing, entity.Position));
        }
        public static Enemy AddEnemy(Objects code, Vector2 position)
        {
            Enemy toAdd = EnemyFactory.CreateObjectFromCode(code, position);
            Enemies.Add(toAdd);
            return toAdd;
        }
        public static void RemoveEnemy(Enemy enemy)
        {
            Enemies.Remove(enemy);
        }
        public static Player GetNearbyPlayer(Vector2 position)
        {
            Player lastPlayer = null;
            int lastDistance = -1;
            foreach (Player player in Players)
            {
                int distance = GeneralUtilities.Distance(position, player.Position);

                if (lastPlayer == null) {
                    lastPlayer = player;
                    lastDistance = distance;
                } else if (lastDistance < distance)
                {
                    lastPlayer = player;
                    lastDistance = distance;
                }
            }
            return lastPlayer;
        }

        public static void PlayerMoved(Player player)
        {
            //Later
        }
        public static Objects GetObjectFromIndex(int layerIndex, int objectIndex)
        {
            return chipInfo.layers[layerIndex].objects[objectIndex].code;
        }
    }
}
