using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Interfaces;
using CHIPS_CHALLENGE.Classes.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Input
{
    public class PlayerInputHandler : IInputHandler
    {
        public Player player;

        private bool upkey = true;
        private bool prevupkey = true;
        private bool disableInput = false;
        private long holdingDown;

        public PlayerInputHandler(Player player)
        {
            this.player = player;
        }
        public void DisableInput()
        {
            disableInput = true;
        }
        public void EnableInput()
        {
            disableInput = false;
        }
        public void HandleInput()
        {
            if (upkey && !disableInput)
            {
                MovePlayer();
            }

            if (prevupkey && !upkey)
            { //Means we changed from not holding to holding down a key
              //Set holding down to now.
              holdingDown = DateTime.Now.Ticks;
              prevupkey = upkey;
            }

            if (!upkey)
            {
                ChipGame.StartGame();
                //If holding down is longer than 1 second, start moving automatically.
                long elapsedTicks = DateTime.Now.Ticks - holdingDown;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                if (elapsedSpan.TotalMilliseconds > 100 && !disableInput)
                {
                    holdingDown = DateTime.Now.Ticks;
                    MovePlayer();
                }
            }

            if (
                Keyboard.GetState().IsKeyUp(Keys.Up)
                && Keyboard.GetState().IsKeyUp(Keys.Down)
                && Keyboard.GetState().IsKeyUp(Keys.Left)
                && Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                upkey = true;
            }
        }

        private void MovePlayer()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                player.Move(new Vector2(0, -1));
                upkey = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                player.Move(new Vector2(0, 1));
                upkey = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                player.Move(new Vector2(-1, 0));
                upkey = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                player.Move(new Vector2(1, 0));
                upkey = false;
            }
        }
    }
}
