using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Cloner : ChipObject
    {
        public Cloner() : base(Objects.CLONER)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            return false;
        }
        public override bool MovingFrom(Entity entity)
        {
            if (entity.waitToBeReleased)
            {
                entity.waitToBeReleased = false;
                return true;
            }
            return false;
        }
    }
}
