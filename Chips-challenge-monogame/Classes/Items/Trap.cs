using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Trap : ChipObject
    {
        public Trap() : base(Objects.TRAP)
        {
        }

        public override bool MovingFrom(Entity entity)
        {
            entity.Trapped = true;
            if (entity.waitToBeReleased)
            {
                entity.Trapped = false;
                entity.waitToBeReleased = false;
                return true;
            }
            return false;
        }
    }
}
