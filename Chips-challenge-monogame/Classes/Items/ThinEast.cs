using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class ThinEast : ChipObject
    {
        public ThinEast() : base(Objects.THIN_EAST)
        {
        }
        public override bool MovingAway(Entity entity)
        {
            if (entity.Velocity.X > 0)
                return false;
            return true;
        }
    }
}
