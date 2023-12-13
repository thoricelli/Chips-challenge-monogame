using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Block : ChipObject
    {
        public Block() : base(Objects.BLOCK)
        {
        }

        public override bool MovingTo(Entity entity)
        {
            this.GoToDirection(entity.Velocity);
            return true;
        } 
    }
}
