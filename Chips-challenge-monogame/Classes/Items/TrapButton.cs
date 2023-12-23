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
    public class TrapButton : ChipObject
    {
        public TrapButton() : base(Objects.TRAP_BUTTON)
        {
        }

        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            ChipGame.ReleaseEnemy(entity.Position);
            base.HasMovedTo(entity, oldVelocity);
        }
    }
}
