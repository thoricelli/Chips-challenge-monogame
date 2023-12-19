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
    public class IceCornerSouthEast : ChipObject
    {
        public IceCornerSouthEast() : base(Objects.ICE_CORNER_SOUTHEAST)
        {
        }
        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            entity.AddPush(new Push(new Vector2(-oldVelocity.Y, -oldVelocity.X), Game.Enums.PushType.MOVEMENT_DISABLED));
        }
    }
}
