using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Items
{
    public class BlueKey : ChipObject
    {
        public BlueKey() : base(Objects.BLUE_KEY)
        {
        }
        public override bool MovingTo(Entity entity)
        {
            this.ChangeObjectInto(Objects.EMPTY);
            ChipGame.Inventory.Blue++;
            return base.MovingTo(entity);
        }
    }
}
