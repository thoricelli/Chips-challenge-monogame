using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class ToggleWallOn : ChipObject
    {
        public ToggleWallOn() : base(Objects.TOGGLE_WALL_ON)
        {
        }

        public override bool MovingTo(Entity entity)
        {
            return false;
        } 
    }
}
