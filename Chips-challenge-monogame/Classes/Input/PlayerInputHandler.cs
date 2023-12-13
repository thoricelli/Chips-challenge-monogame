using CHIPS_CHALLENGE.Classes.Entities;
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

        private bool upprev = true;

        public PlayerInputHandler(Player player)
        {
            this.player = player;
        }

        public void HandleInput()
        {
            if (upkey)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    thisPlayer.Move(new Vector2(0, -1));
                    upkey = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    thisPlayer.Move(new Vector2(0, 1));
                    upkey = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    thisPlayer.Move(new Vector2(-1, 0));
                    upkey = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    thisPlayer.Move(new Vector2(1, 0));
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
