using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class GreenDoor : ChipObject
    {
        public GreenDoor() : base(Objects.GREEN_DOOR)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            this.ChangeObjectInto(Objects.EMPTY);
            return ChipGame.Inventory.Green;
        }
    }
}
