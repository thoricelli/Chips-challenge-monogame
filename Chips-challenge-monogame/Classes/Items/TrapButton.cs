using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Interfaces;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class TrapButton : ChipObject, IPressable
    {
        public TrapButton() : base(Objects.TRAP_BUTTON)
        {
        }

        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            Press(entity.Position);
            base.HasMovedTo(entity, oldVelocity);
        }

        public Object Press(Vector2 position)
        {
            ChipGame.ReleaseEnemy(position);
            return null;
        }
    }
}
