using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class ThinSouth : ChipObject
    {
        public ThinSouth() : base(Objects.THIN_SOUTH)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            if (entity.Velocity.Y < 0)
                return false;
            return true;
        }
        public override bool MovingFrom(Entity entity)
        {
            if (entity.Velocity.Y > 0)
                return false;
            return true;
        }
    }
}
