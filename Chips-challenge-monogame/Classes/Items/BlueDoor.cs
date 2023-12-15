using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class BlueDoor : ChipObject
    {
        public BlueDoor() : base(Objects.BLUE_DOOR)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            if (ChipGame.Inventory.Blue)
                this.ChangeObjectInto(Objects.EMPTY);
            return ChipGame.Inventory.Blue;
        }
    }
}
