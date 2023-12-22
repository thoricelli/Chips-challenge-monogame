using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class TeleportButton : ChipObject
    {
        public TeleportButton() : base(Objects.TELEPORT_BUTTON)
        {
        }

        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            entity.Position = ChipGame.PositionOfTileInReverse(Objects.TELEPORT_BUTTON, entity.Position);
        }
    }
}
