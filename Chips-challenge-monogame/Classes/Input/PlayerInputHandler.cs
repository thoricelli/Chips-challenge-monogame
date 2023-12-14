using CHIPS_CHALLENGE.Classes.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Input
{
    public class PlayerInputHandler
    {
        public Player player;

        private bool upkey = true;
        private bool disableInput = false;

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

            if (
                Keyboard.GetState().IsKeyUp(Keys.Up)
                && Keyboard.GetState().IsKeyUp(Keys.Down)
                && Keyboard.GetState().IsKeyUp(Keys.Left)
                && Keyboard.GetState().IsKeyUp(Keys.Right))
                upkey = true;
        }
    }
}
