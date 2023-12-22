using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Game;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class WallButton : ChipObject
    {
        public WallButton() : base(Objects.WALL_BUTTON)
        {
        }

        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            //Have toggle in the class instead?
            GameUpdate.ReplaceTile(Objects.TOGGLE_WALL_ON, Objects.TOGGLE_WALL_OFF);
            GameUpdate.ReplaceTile(Objects.TOGGLE_WALL_OFF, Objects.TOGGLE_WALL_ON);
        }
    }
}
