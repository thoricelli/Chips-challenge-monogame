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
    public class TankButton : ChipObject
    {
        public TankButton() : base(Objects.TANK_BUTTON)
        {
        }

        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            GameUpdate.SwitchDirection(Entities.Enums.Enemies.TANK);
        }
    }
}
