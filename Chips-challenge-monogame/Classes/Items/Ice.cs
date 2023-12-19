using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Game;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Ice : ChipObject
    {
        public Ice() : base(Objects.ICE)
        {
        }
        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            if (!ChipGame.Inventory.IceShoe)
                entity.AddPush(new Push(oldVelocity, Game.Enums.PushType.ICE));
        }
    }
}
