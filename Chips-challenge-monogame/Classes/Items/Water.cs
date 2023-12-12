using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class Water : ChipObject
    {
        public Water() : base(Objects.WATER)
        {

        }

        public override bool MovingTo(Entity entity)
        {
            entity.Kill();
            return true;
        }
    }
}
