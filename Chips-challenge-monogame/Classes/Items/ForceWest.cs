using CHIPS_CHALLENGE.Classes.Entities;
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
    public class ForceWest : ChipObject
    {
        public ForceWest() : base(Objects.FORCE_NORTH)
        {
        }
        public override void HasMovedTo(Entity entity, Vector2 oldVelocity)
        {
            entity.AddPush(new Vector2(-1,0));
        }
    }
}
