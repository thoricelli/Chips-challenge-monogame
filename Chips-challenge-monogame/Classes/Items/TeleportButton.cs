using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Interfaces;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class TeleportButton : ChipObject, IPressable
    {
        public TeleportButton() : base(Objects.TELEPORT_BUTTON)
        {
        }

        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            entity.ChangePosition(GetTeleportPosition(entity.Position));
        }

        public Vector2 GetTeleportPosition(Vector2 position)
        {
            return (Vector2)Press(position);
        }

        public Object Press(Vector2 position)
        {
            return ChipGame.PositionOfTileInReverse(Objects.TELEPORT_BUTTON, position);
        }
    }
}
