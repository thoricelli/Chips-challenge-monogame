using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class YellowDoor : ChipObject
    {
        public YellowDoor() : base(Objects.YELLOW_DOOR)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            return ChipGame.Inventory.Yellow;
        }
    }
}
